namespace OnlineShop.Common.ResultPattern;

public class Result<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public List<string> Error { get; set; }

    public static Result<T> SuccessResult(T data, string message = "")
    {
        return new Result<T>()
        {
            Data = data,
            Message = message,
            Success = true
        };
    }

    public static Result<T> ErrorResult(List<string> error, string message = "شما یک خطای پیش بینی نشده دارید !")
    {
        return new Result<T>()
        {
            Success = false,
            Message = message,
            Error = error

        };
    }
    
    public static Result<T> ErrorResult(string error, string message = "شما یک خطای پیش بینی نشده دارید !")
    {
        return new Result<T>()
        {
            Success = false,
            Message = message,
            Error = new List<string>(){error}

        };
    }
}


 