namespace MicroservicesToDocker.Models.Response.BrandResponses
{
    public class UpdateBrandResponse<T>
    {
        public T UpdateState { get; set; } = default!;
    }
}
