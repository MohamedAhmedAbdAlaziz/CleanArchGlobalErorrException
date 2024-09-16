using API.Errors;

namespace API.Error
{
    public class FailResponse : ApiResponse
    {
        //public FailResponse(int statusCode, string message = null) : base(statusCode, message)
        //{
        //    Errors = GetDefaultErrorForStatusCode(statusCode);
        //}
        public FailResponse(int statusCode, string message = null, string[] errors= null) : base(statusCode, message)
        {
            Errors = errors?? GetDefaultErrorForStatusCode(statusCode);
        }
        public string[] Errors { get; set; }
        private string[] GetDefaultErrorForStatusCode(int statusCode)
        {
            string? result = statusCode switch
            { 
                400 => "A bad request,you have made",
                403 => "A validation errors",
                401 => "Authorized,you are not allowed",
                404 => "Resource not Found , it was not",
                500 => "Internal Server Error",
                _ => null
            };

            return new string[] { result };
        }
    }
}
