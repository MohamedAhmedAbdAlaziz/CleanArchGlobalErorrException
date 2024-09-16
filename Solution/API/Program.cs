using API.Error;
using API.Errors;
using API.Extensions;
using API.Middleware;
using Application;
using Infrastructure.Data;
using Core.Models;
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Text.Json;
using BuildingBlocks.Exceptions.Handler;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));

});

builder.Services.AddAPIServices().AddApplicationServices();

//var appSettingsSection = builder.Configuration.GetSection("FcmNotification");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddMvc().AddNewtonsoftJson(options =>
{
    //options.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.Configure<ApiBehaviorOptions>(options => {
    options.InvalidModelStateResponseFactory = actionContext => {
        var erorrs = actionContext.ModelState
      .Where(e => e.Value.Errors.Count > 0)
       .SelectMany(x => x.Value.Errors)
        .Select(x => x.ErrorMessage).ToArray();
        var erroResponse = new FailResponse(400)
        {

            Errors = erorrs

        };
        return new BadRequestObjectResult(erroResponse);
    };
});
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = "Bearer"; // Use bearer token authentication
//    options.DefaultChallengeScheme = "Bearer"; // Use bearer token authentication
//}).AddIdentityServerAuthentication("Bearer", options =>
//{
//    options.ApiName = builder.Configuration["IdentityAPIName"];
//    options.Authority = builder.Configuration["IdentityAuthority"];

//    //options.EnableCaching = true;
//    //options.CacheDuration = TimeSpan.FromHours(1);
//    options.SupportedTokens = SupportedTokens.Jwt;

//});
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(builder.Configuration["CRMUrl"]);
    });
});
builder.Services.AddswaggerDocmentation();
var app = builder.Build();

//app.UseMiddleware<ExceptionMiddleware>();
app.UseExceptionHandler(o => { });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocmentation();
    //app.UseStatusCodePagesWithReExecute("/erorr/{0}");
    app.UseStatusCodePagesWithReExecute("/errorhandler/error-development");
    //  app.UseSwagger();
    //app.UseSwaggerUI();
}
else
{
  app.UseStatusCodePagesWithReExecute("/errorhandler/error");

}
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

app.Run();
