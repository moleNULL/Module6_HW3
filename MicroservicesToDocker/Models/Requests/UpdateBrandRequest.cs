namespace MicroservicesToDocker.Models.Requests
{
    public class UpdateBrandRequest
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
    }
}
