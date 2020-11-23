using System;
using System.Net;
using System.Net.Mail;

namespace TestSMTPSendMail
{
    public class Program
    {
        private static string subject = "Testing Mail from console app.... ";
        private static string message =
            @"<html>" +
            "<body>" +
            "<h1> Testing Email From console App </h1>" +
            "</body>" +
            "</html>";

        static void Main(string[] args)
        {
            Console.ReadLine();
            using (var client = new SmtpClient())
            {
                try
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "sender@mail.com",
                        Password = "yourpassword"
                    };

                    client.Credentials = credential;
                    client.Host = "smtp.ieg.id";
                    client.Port = 25;
                    client.EnableSsl = true;

                    using (var emailMessage = new MailMessage())
                    {
                        emailMessage.To.Add(new MailAddress("receiver1@mail.co"));
                        emailMessage.To.Add(new MailAddress("receiver2@mail.co"));
                        emailMessage.From = new MailAddress("sender@mail.com", "Notification");
                        emailMessage.Subject = subject;
                        emailMessage.Body = message;
                        emailMessage.IsBodyHtml = true;
                        client.Send(emailMessage);
                        Console.WriteLine("sended..");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            System.Threading.Thread.Sleep(5000);
            Console.ReadLine();
        }
    }
}
