namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Status = (statusCode/100) == 2;
         
        }



        public int StatusCode { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
      

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "succeeded",
                201 => "Created succeessfully",
                400 => "A bad request,you have made",
                403 => "A validation errors",
                401 => "Un authorized,you are not allowed",
                404 => "Resource not Found , it was not",
                500 => "Internal Server Error",
                _ => null
            };
        }

   
    }
}