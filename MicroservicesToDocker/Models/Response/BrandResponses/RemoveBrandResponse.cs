namespace MicroservicesToDocker.Models.Response.BrandResponses
{
    public class RemoveBrandResponse<T>
    {
        public T RemoveState { get; set; } = default!;
    }
}
