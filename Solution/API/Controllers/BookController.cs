using Application.Execptions;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   
    public class BookController(IBookServices bookServices) : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            throw new BookNotFoundExecption("Mohamed");
            return Ok(await bookServices.GetBooks());
        }

       
    }
}
