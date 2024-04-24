using Krugozor.Models;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Krugozor.Services.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendAsync(MailData mailData);
    }
}
