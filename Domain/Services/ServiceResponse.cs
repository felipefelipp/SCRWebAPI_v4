namespace SCRWebAPI_v4.Domain.Services
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } 
    }
}
