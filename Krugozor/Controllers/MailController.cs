using Krugozor.Models;
using Krugozor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Pkcs;
using System.Diagnostics;

namespace Krugozor.Controllers
{
    public class MailController : Controller
    {
        private readonly ILogger<MailController> _logger;
        private readonly IMailService _mail;
        private readonly MailData _mailData;
        public MailController(ILogger<MailController> logger, IMailService mail, MailData mailData)
        {
            _logger = logger;
            _mail = mail;
            _mailData = mailData;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<bool> SendMessage()
        {
            try
            {
                User user = new User()
                {
                    Firstname = Request.Form["firstname"],
                    Lastname = Request.Form["lastname"],
                    Phone = Request.Form["phone"],
                    Email = Request.Form["email"]
                };

                _mailData.Body = $"Пользователь сайта {user.Firstname} {user.Lastname} оставил заявку. Контактные данные: \nТелефон - {user.Phone} \nПочта - {user.Email}";

                bool result = await _mail.SendAsync(_mailData);

                if (result)
                {
                    _logger.LogInformation("Сообщение успешно отправлено.");
                    return true;// Вернуть ответ об успешном выполнении
                }
                else
                {
                    _logger.LogInformation("Сообщение не было отправлено.");
                    return false; // Вернуть ответ о неуспешном выполнении
                }
                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.GetBaseException().Message);
                return false;
            }
        }
    }
}