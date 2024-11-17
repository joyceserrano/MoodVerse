using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MoodVerse.Utility.Emails.Interface;
using MoodVerse.Utility.Emails.Model;

namespace MoodVerse.Utility.Emails
{
    public class EmailDispatcher : IEmailDispatcher
    {

        private EmailSetting EmailSetting { get; }

        public EmailDispatcher(IOptions<EmailSetting> emailSetting) {
            EmailSetting = emailSetting.Value;
        }

        public async Task SendAsync(string subject, string content)
        {
            try
            {
                var mail = new MimeMessage();
                mail.From.Add(new MailboxAddress(EmailSetting.Username, EmailSetting.Email));
                mail.To.Add(new MailboxAddress(EmailSetting.TestEmail, EmailSetting.TestEmail));
                mail.Subject = subject;
                mail.Body = new TextPart("plain") { Text = content };

                using var client = new SmtpClient();

                await client.ConnectAsync(EmailSetting.Host, EmailSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(EmailSetting.Email, EmailSetting.Password);
                await client.SendAsync(mail);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}