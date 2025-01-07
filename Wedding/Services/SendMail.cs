
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Wedding.Models;

namespace Wedding.Services {
    public class SendMail : ISendMail {

        public SendMail(IOptions<MailOptions> options) {
            this.options = options.Value;
        }

        private readonly MailOptions options;

        public async Task SendMessage(string messageText) {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Ответ на приглашение", options.EmailFrom));
            message.To.Add(new MailboxAddress("Свадьба", options.EmailTo));
            message.Subject = "Приглашение на свадьбу";

            message.Body = new TextPart("plain") {
                Text = messageText
            };

            using (SmtpClient client = new SmtpClient()) {
                await client.ConnectAsync(options.Host, options.Port, options.UseSsl);
                await client.AuthenticateAsync(options.UserName, options.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
