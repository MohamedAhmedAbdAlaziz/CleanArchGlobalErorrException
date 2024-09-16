using API.Errors;

namespace API.Error;
public class SucceededRespone : ApiResponse
{
    public SucceededRespone(int statusCode, string message = null) : base(statusCode, message)
    {
    }
    public object Data { get; set; }

}