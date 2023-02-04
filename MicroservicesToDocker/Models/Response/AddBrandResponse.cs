namespace MicroservicesToDocker.Models.Response
{
    public class AddBrandResponse<T>
    {
        public T Id { get; set; } = default(T) !;
    }
}
