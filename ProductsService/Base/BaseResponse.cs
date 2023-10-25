namespace ProductsService.Base
{
    public class BaseResponse<T> : BaseResponse
    {
        public new T Data { get; private set; } = default;

        public BaseResponse(bool success, int resultCode, string msg = "", T data = default) : base(success, resultCode, msg)
        {
            Data = data;
        }


    }

    public class BaseResponse
    {
        public virtual bool Error { get; set; } = false;
        public virtual bool Success { get; set; } = false;
        public virtual string Message { get; set; } = string.Empty;
        public virtual object? Data { get; set; } = null;
        public virtual int ResultCode { get; set; } = 0;

        public BaseResponse(bool success, int resultCode = 0, string msg = "")
        {
            Success = success;
            Error = !success;
            ResultCode = resultCode;
            Message = msg;
        }
    }
}
