//using MailKit.Security;
//using MimeKit;
//using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using MailKit.Net.Smtp;


namespace EmailReader //rename
{
    public class EmailFileRead
    {
        public EmailFileRead()
        {

        }

        public static string fileName1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public static String ReadText(String fileName = "")
        {
            if (fileName == "")
                fileName = fileName1;
            if (File.Exists(fileName))
                return File.ReadAllText(fileName);
            else
            {
                File.WriteAllText(fileName, "");
                return "";
            }
        }

        public static void WriteText(String text, String fileName = "")
        {
            if (fileName == "")
                fileName = fileName1;
            string format = "MM/dd/yyyy";
            String date = "\n" + DateTime.Now.ToString(format) + ":\n";
            if (File.ReadAllText(fileName).Contains(DateTime.Now.ToString(format)))
                date = "";//"\n";
            File.AppendAllText(fileName,date+text);
        }

        public static void DeleteText(String fileName = "")
        {
            if (fileName == "")
                fileName = fileName1;
            File.WriteAllText(fileName, "");
        }

        public static void DeleteLastLine(String fileName = "")
        {
			if (fileName == "")
                fileName = fileName1;
            var v = File.ReadAllLines(fileName).ToList<String>();
            if (v.Count > 0)
            {
                v.Remove(v.Last());
                v.RemoveAll(x=>x==String.Empty);
            }
            File.WriteAllLines(fileName, v);
        }

        public static bool ValidateEmail(String email = "")
        {
            return email.Contains("@") && email.Contains(".") && email!="";
        }
        /*
        public static void EmailTestResultsEmail(String e, String fileText = "", String fileInfo = "", int seconds = 20)
        {
            try
            {
                // create email message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(Credentials.emailFrom));
                email.To.Add(MailboxAddress.Parse(e));
                email.Subject = "Your story creative...";
                var part = new TextPart(TextFormat.Html) { Text = "<h1>Your story</h1>" };
                var part2 = new TextPart(TextFormat.Plain) { Text = "Welcome to your story creative!\n" };
                var part3 = new TextPart(TextFormat.Plain) { Text = fileText };
                var multipart = new Multipart("mixed");

                if (fileInfo != "")
                {
                    // create an image attachment for the file located at path
                    var attachment = new MimePart()
                    {
                        Content = new MimeContent(File.OpenRead(fileInfo)),
                        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        FileName = Path.GetFileName(fileInfo)
                    };

                    // now create the multipart/mixed container to hold the message text and the
                    // image attachment
                    multipart.Add(attachment);                   
                }
                multipart.Add(part);
                multipart.Add(part2);
                multipart.Add(part3);
                email.Body = multipart;

                // send email
                var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(Credentials.SMTPEmail, Credentials.SMTPPassword);
                smtp.Send(email);
                Thread.Sleep(1000 * seconds);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }*/

        public static void DeleteFileAfterMonths(String fileName = "", int month = 12)
        {
            if (fileName == "")
                fileName = fileName1;

            var fi = new FileInfo(fileName);
            if (fi.CreationTime > DateTime.Now.AddMonths(-1 * month))
                fi.Delete();

        }

        public static bool FileSizeWarning(String fileName = "", long size = 1024000000)
        {
            if (fileName == "")
                fileName = fileName1;

            var fi = new FileInfo(fileName);
            return fi.Length > size;
        }
        /*
        public static void EmailDev(String e, String devemail = "", int seconds = 20)
        {
            try
            {
                // create email message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(Credentials.emailFrom));
                email.To.Add(MailboxAddress.Parse(e));
                email.Subject = "Your story creative...";
                var part = new TextPart(TextFormat.Html) { Text = "<h1>Your story</h1>" };
                var part2 = new TextPart(TextFormat.Plain) { Text = "Here is your story booklet! Emailed to you at " + DateTime.Now.ToString() + "\nThe email is " + email };

                var multipart = new Multipart("mixed");

                multipart.Add(part);
                multipart.Add(part2);

                // send email
                var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(Credentials.SMTPEmail, Credentials.SMTPPassword);
                smtp.Send(email);
                Thread.Sleep(1000 * seconds);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debug.Write(ex.ToString());
            }
        }*/
    }
}
