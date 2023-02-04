namespace MicroservicesToDocker.Models.Response
{
    public class RemoveBrandResponse<T>
    {
        public T RemoveState { get; set; } = default(T) !;
    }
}
