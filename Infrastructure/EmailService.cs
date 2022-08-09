using MimeKit;

namespace Ipsum.Infrastructure
{
    public class EmailService
    {
        private readonly ILogger<EmailService> _logger;
        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public void SendLetter(string recipientEmail)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Ipsum Dev.", "v.kozenkov@foxford.ru"));
                message.To.Add(new MailboxAddress("Recipient", recipientEmail));
                message.Subject = "Сообщение от Ipsum Dev.";
                message.Body = new BodyBuilder() { HtmlBody = "<div style=\"color: green;\">Подписка успешно оформлена</div>"}.ToMessageBody();

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("v.kozenkov@foxford.ru", "30zomumi");
                    client.Send(message);

                    client.Disconnect(true);
                    _logger.LogInformation($"Message sent. Rescipient: {recipientEmail}");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.GetBaseException().Message);
            }
        }
    }
}
