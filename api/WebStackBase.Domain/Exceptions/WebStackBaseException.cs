using System.Net;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging;

namespace WebStackBase.Domain.Exceptions;

[Serializable]
public class WebStackBaseException : BaseException
{
    public override LogLevel LogLevel { get; set; } = LogLevel.Information;

    public override HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.Conflict;

    public WebStackBaseException(string mensaje) : base(mensaje)
    {
    }

    protected WebStackBaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}