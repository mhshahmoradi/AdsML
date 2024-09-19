namespace AdsML.Common.Shared;

public class OperationResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public OperationResult(bool isSucceeded, string message)
    {
        IsSuccess = isSucceeded;
        Message = message;
    }

    public static OperationResult Succeeded(string message = "عملیات با موفقیت انجام شد.") => new(message: message, isSucceeded: true);
    public static OperationResult Failed(string message) => new(message: message, isSucceeded: false);

}
