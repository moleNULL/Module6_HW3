namespace MicroservicesToDocker.Models.Response
{
    public class UpdateItemResponse<T>
    {
        public T UpdateState { get; set; } = default(T) !;
    }
}
