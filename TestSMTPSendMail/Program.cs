using System;
using System.IO;
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

        //OFFICE 365
        //static void Main(string[] args)
        //{
        //    Console.ReadLine();
        //    using (var client = new SmtpClient())
        //    {
        //        try
        //        {
        //            var credential = new NetworkCredential
        //            {
        //                UserName = "she-salus@timurbahari.co.id",
        //                Password = "Safepedia4567"
        //            };

        //            client.Credentials = credential;
        //            client.Host = "smtp.office365.com";
        //            client.Port = 587;
        //            client.EnableSsl = false;

        //            using (var emailMessage = new MailMessage())
        //            {
        //                emailMessage.To.Add(new MailAddress("she-salus@timurbahari.co.id"));
        //                emailMessage.From = new MailAddress("she-salus@timurbahari.co.id", "Notification");
        //                emailMessage.Subject = subject;
        //                emailMessage.Body = message;
        //                emailMessage.IsBodyHtml = true;
        //                client.Send(emailMessage);
        //                Console.WriteLine("sended..");
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);

        //        }
        //    }
        //    System.Threading.Thread.Sleep(5000);
        //    Console.ReadLine();
        //}

        // GMAIL
        static void Main(string[] args)
        {
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;

            Console.ReadLine();
            try
            {
                string folderName = @"C:\logs\";
                var pathString = System.IO.Path.Combine(folderName, $"log-proses-testemailconsole-{DateTime.Today.Date.ToString("dd-MM-yyyy")}.txt");
                ostrm = new FileStream(pathString, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
            using (var client = new SmtpClient())
            {
                try
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "system.notification.8000@gmail.com",
                        Password = "10qpalzm!"
                    };

                    client.Credentials = credential;
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;

                    using (var emailMessage = new MailMessage())
                    {
                        emailMessage.To.Add(new MailAddress("system.notification.8000@gmail.com"));
                        emailMessage.From = new MailAddress("system.notification.8000@gmail.com", "Notification");
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
            Console.WriteLine("result : ");
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine("Done");

        }

    }
}
