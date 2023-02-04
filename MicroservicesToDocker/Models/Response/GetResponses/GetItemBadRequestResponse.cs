namespace MicroservicesToDocker.Models.Response.GetResponses
{
    public class GetItemBadRequestResponse<T>
    {
        public T ResponseState { get; set; } = default!;
    }
}
