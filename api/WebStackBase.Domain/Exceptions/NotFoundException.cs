using System.Net;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging;

namespace WebStackBase.Domain.Exceptions;

[Serializable]
public class NotFoundException : BaseException
{
    public override LogLevel LogLevel { get; set; } = LogLevel.Information;

    public override HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.NotFound;

    public NotFoundException(string mensaje) : base(mensaje)
    {
    }

    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
