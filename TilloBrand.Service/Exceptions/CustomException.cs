namespace TilloBrand.Service.Exceptions;

public class CustomException : Exception
{
    public int statusCode {  get; set; }

    public CustomException(int code, string message) : base(message)
    {
        this.statusCode = code;
    }
}
