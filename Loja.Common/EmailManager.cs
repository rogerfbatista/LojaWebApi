using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Common
{
    public class EmailManager
    {
        

        public static async Task EnviarEmailStaticTask(string assunto,StringBuilder corpo, string destinario, List<Attachment> listAnexo)
        {
            const string sUserName = "rogerfbatista@gmail.com";
            const string sPassword = "031203bi";


            var objEmail = new MailMessage();
            
                objEmail.To.Add(destinario);
            

            foreach (var anexo in listAnexo)
            {
                objEmail.Attachments.Add(anexo);
            }

            objEmail.From = new MailAddress(sUserName.Trim());
            objEmail.Subject = assunto;
            objEmail.Body = corpo.ToString();
            objEmail.SubjectEncoding = Encoding.UTF8;
            objEmail.BodyEncoding = Encoding.UTF8;
            objEmail.Priority = MailPriority.Normal;



            try
            {
                using (var smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new NetworkCredential(sUserName, sPassword);
                    await smtp.SendMailAsync(objEmail);
                }

            }
            catch (SmtpException e)
            {

                throw new Exception(e.Message + e.StatusCode);
            }
        }
      
        public async Task EnviarEmail(string assunto,StringBuilder corpo, List<string> listDestinario, List<Attachment> listAnexo)
        {

            const string sUserName = "rogerfbatista@sonicti.somee.com";
            const string sPassword = "031203bianca";


            var objEmail = new MailMessage();
            foreach (var destinario in listDestinario)
            {
                objEmail.To.Add(destinario);
            }


            foreach (var anexo in listAnexo)
            {
                objEmail.Attachments.Add(anexo);
            }

            objEmail.Bcc.Add("rogerfbatista@gmail.com");
            objEmail.From = new MailAddress(sUserName.Trim());
            objEmail.Subject = assunto;
            objEmail.Body = corpo.ToString();
            objEmail.SubjectEncoding = Encoding.UTF8;
            objEmail.BodyEncoding = Encoding.UTF8;
            objEmail.Priority = MailPriority.Normal;



            try
            {
                using (var smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new NetworkCredential(sUserName, sPassword);
                    await smtp.SendMailAsync(objEmail);
                }

            }
            catch (Exception e)
            {

                e = null;
            }
            finally
            {
                objEmail.Dispose();
            }
        }


    }
}