using Krugozor.Controllers;
using Krugozor.Models;
using Krugozor.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Krugozor.Services
{
    public class MailService : IMailService
    {
        private readonly ILogger<MailSettings> _logger;
        private readonly MailSettings _settings;

        public MailService(IOptions<MailSettings> settings, ILogger<MailSettings> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task<bool> SendAsync(MailData mailData)
        {
            try
            {
                var mail = new MimeMessage();

                #region Sender / Receiver
                // Sender
                mail.From.Add(new MailboxAddress(mailData.DisplayName, _settings.UserName));
                mail.Sender = new MailboxAddress(mailData.DisplayName, _settings.UserName);

                // Receiver
                mail.To.Add(MailboxAddress.Parse(mailData.To));
                #endregion

                #region Content

                var body = new BodyBuilder();
                mail.Subject = mailData.Subject;
                body.HtmlBody = mailData.Body;
                mail.Body = body.ToMessageBody();

                #endregion

                #region Send Mail

                using (var client = new SmtpClient())
                {
                    try
                    {
                        await client.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect);
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        client.Authenticate(_settings.UserName, _settings.Password);
                        await client.SendAsync(mail);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        await client.DisconnectAsync(true);
                        client.Dispose();
                    }
                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetBaseException().Message);
                return false;
            }
        }
    }
}
    

