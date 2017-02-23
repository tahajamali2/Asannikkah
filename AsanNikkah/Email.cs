using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace AsanNikkah
{
    public class Email
    {
        public static string Send(string To_Email,string subject,string Html_Body,string From_Name,string From_Email,string From_Password,string Host,int Port,bool isssl)
        {
            try
            {
                var fromAddress = new MailAddress(From_Email, From_Name);
                var toAddress = new MailAddress(To_Email);

                var smtp = new SmtpClient
                {
                    Host = Host,
                    Port = Port,
                    EnableSsl = isssl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, From_Password)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = Html_Body,
                    IsBodyHtml = true,
                })
                {
                    smtp.Send(message);
                }

                return "Sent";
            }
            catch
            {
                return "Error";
            }
        }
    }
}