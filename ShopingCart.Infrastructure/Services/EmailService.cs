using Microsoft.Extensions.Configuration;
using ShopingCart.Application.Core.Models;
using ShopingCart.Application.Core.Services;
using System.Net;
using System.Net.Mail;

namespace ShopingCart.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerService _logService;

        public EmailService(IConfiguration configuration, ILoggerService logService)
        {
            _configuration = configuration;
            _logService = logService;
        }

        public void SenMail(Email email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email.From) || string.IsNullOrWhiteSpace(email.To)) return;
                using (var smtpClient = new SmtpClient())
                {
                    var deliveryMethod = _configuration.GetSection("Smt:DeliveryMethod").Value;
                    if (deliveryMethod == SmtpDeliveryMethod.SpecifiedPickupDirectory.ToString())
                    {
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                        smtpClient.PickupDirectoryLocation = _configuration.GetSection("Smt:PickupDirectoryLocation").Value;
                    }
                    else if (deliveryMethod == SmtpDeliveryMethod.Network.ToString())
                    {
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.Host = _configuration.GetSection("Smt:Host").Value;
                        smtpClient.Port = Convert.ToInt32(_configuration.GetSection("Smt:Port").Value);
                        smtpClient.Credentials = new NetworkCredential(_configuration.GetSection("Smt:Name").Value, _configuration.GetSection("Smt:Password").Value);
                        smtpClient.EnableSsl = Convert.ToBoolean(_configuration.GetSection("Smt:EnableSsl").Value);
                    }

                    using (var mailMessage = new MailMessage())
                    {

                        var mailAddress = new MailAddress(email.From);
                        if (!string.IsNullOrWhiteSpace(email.To))
                        {
                            var emailTo = email.To.Split(';');
                            foreach (var tomail in emailTo)
                            {
                                mailMessage.To.Add(tomail);
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(email.Cc))
                        {
                            var ccmail = email.Cc.Split(';');
                            foreach (var cmail in ccmail)
                            {
                                mailMessage.CC.Add(cmail);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(email.BCc))
                        {
                            var bccmail = email.BCc.Split(';');
                            foreach (var bcmail in bccmail)
                            {
                                mailMessage.Bcc.Add(bcmail);
                            }
                        }

                        mailMessage.Subject = email.Subject;
                        mailMessage.Body = email.Body;
                        mailMessage.IsBodyHtml = true;

                        if (email.Attachments != null || email.Attachments.Count > 0)
                        {
                            foreach (var attachment in email.Attachments)
                            {
                                mailMessage.Attachments.Add(attachment.File);
                            }
                        }

                        smtpClient.Send(mailMessage);

                    }
                }

            }
            catch (Exception ex)
            {
                _logService.LogException(ex);

            }

        }
    }
}