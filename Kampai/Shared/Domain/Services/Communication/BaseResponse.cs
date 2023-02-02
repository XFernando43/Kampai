namespace Kampai.Shared.Domain.Services.Communication;

public abstract class BaseResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Resource { get; set; }
    
    protected BaseResponse(T resource)
    {
        Success = true;
        Resource = resource;
        Message = String.Empty;
    }
    protected BaseResponse(String message)
    {
        Success = true;
        Resource = default;
        Message = message;
    }
}