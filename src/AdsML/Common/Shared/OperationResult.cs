namespace AdsML.Common.Shared;

public class OperationResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public OperationResult(bool isSuccedded, string message)
    {
        IsSuccess = isSuccedded;
        Message = message;
    }

    public static OperationResult Succeeded(string message = "عملیات با موفقیت انجام شد.") => new(message: message, isSuccedded: true);
    public static OperationResult Failed(string message) => new(message: message, isSuccedded: false);

}
