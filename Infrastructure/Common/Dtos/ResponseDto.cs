namespace ParkingUNAH.Infrastructure.Common.Dtos
{
    public sealed class ResponseDto<T>()
    {
        public bool Ok { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static ResponseDto<T> Success(T data, string? message = "")
        {
            return new ResponseDto<T>
            {
                Ok = true,
                Message = message,
                Data = data
            };
        }

        public static ResponseDto<T> Error(string message)
        {
            return new ResponseDto<T>
            {
                Ok = false,
                Message = message,
            };
        }
    }
}
