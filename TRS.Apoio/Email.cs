using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Murta.Apoio
{
    public class Email
    {
        protected MailMessage mail = null;

        protected SmtpClient smtpClient = null;

        public Email()
        {
            this.mail = new MailMessage();
            this.smtpClient = this.ConfiguraSmtp();
        }

        public Email(string remetente, string destinatarios):this()
        {
            this.mail.From = new MailAddress(remetente);
            this.mail.To.Add(destinatarios);
        }

        public Email(string remetente, string destinatarios, string assunto, string mensagem):this(remetente, destinatarios)
        {
            this.mail.Subject = assunto;
            this.mail.Body = mensagem;
            this.mail.IsBodyHtml = true;
        }

        public void AddRemetente(string remetente)
        {
            this.mail.From = new MailAddress(remetente);
        }

        public void AddDestinatario(string destinararios)
        {
            this.mail.To.Add(destinararios);
        }

        public void AddDestinatarioComCopia(string destinatariosCC)
        {
            this.mail.CC.Add(destinatariosCC);
        }

        public void AddDestinatarioComCopiaOculta(string destinatarioCCO)
        {
            this.mail.Bcc.Add(destinatarioCCO);
        }

        public void AddMensagem(string assunto, string corpo)
        {
            this.mail.Subject = assunto;
            this.mail.Body = corpo;
            this.mail.IsBodyHtml = true;
        }

        public void AddAnexo(Attachment item)
        {
            this.mail.Attachments.Add(item);
        }

        public bool Enviar()
        {
            try
            {
                this.smtpClient.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected SmtpClient ConfiguraSmtp()
        {                                                                  
            SmtpClient host = new SmtpClient();
            host.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();
            host.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPorta"].ToString());
            host.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailRemetente"].ToString(), ConfigurationManager.AppSettings["SenhaRepetente"].ToString());
            return host;
        }

    }
}
