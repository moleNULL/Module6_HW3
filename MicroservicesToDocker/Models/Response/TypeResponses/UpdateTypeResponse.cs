﻿namespace MicroservicesToDocker.Models.Response.TypeResponses
{
    public class UpdateTypeResponse<T>
    {
        public T UpdateState { get; set; } = default!;
    }
}
