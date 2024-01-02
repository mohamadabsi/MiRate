using Microsoft.Extensions.Configuration;

namespace Framework.Attachments
{
    public interface IAttachmentsServicesConfig
    {
        IConfiguration Configuration { get; }
    }
}