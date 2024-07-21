using System;
using MailKit.Net.Smtp;
using MimeKit;

public class EmailHelper
{
    public static void SendEmail(string toEmail, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Nicat", "nicatakbarli571@gmail.com"));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;

        message.Body = new TextPart("plain")
        {
            Text = body
        };

        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("nicatakbarli571@gmail.com", "gwph lbwm vvaz bypj");
                client.Send(message);
                client.Disconnect(true);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
