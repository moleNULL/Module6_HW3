namespace MicroservicesToDocker.Models.Response.TypeResponses
{
    public class RemoveTypeResponse<T>
    {
        public T RemoveState { get; set; } = default!;
    }
}
