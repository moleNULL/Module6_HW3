namespace MicroservicesToDocker.Models.Response
{
    public class GetItemBadRequestResponse<T>
    {
        public T ResponseState { get; set; } = default(T) !;
    }
}
