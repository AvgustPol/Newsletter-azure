using Newsletter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Newsletter.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmailSenderController : Controller
    {
        public EmailSender emailSender =
            new EmailSender("smtp.gmail.com", 587, "serwisnewsletterazure@gmail.com", "n@t@127a!", true);

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Send(string text)
        {
            ApplicationDbContext applicationUsers = new ApplicationDbContext();

            foreach (ApplicationUser user in applicationUsers.Users)
            {
                emailSender.SendEmail(user.Email, "Newsletter message", text);
            }
            
            return View();
        }
    }

    public class EmailSender
    {
        private readonly string sender_;
        private readonly SmtpClient smtpClient_;

        public EmailSender(string _smtpServer, int _port, string _username, string _password, bool _enableSsl)
        {
            if (string.IsNullOrEmpty(_smtpServer))
                throw new ArgumentException("Adres serwera SMTP nie może być pusty!");
            if (_port < 1 || _port > 65535)
                throw new ArgumentException("Nieprawidłowy numer portu!");
            if (string.IsNullOrEmpty(_username))
                throw new ArgumentException("Nazwa użytkownika nie może być pusta!");
            if (string.IsNullOrEmpty(_password))
                throw new ArgumentException("Hasło użytkownika nie może być puste!");

            sender_ = _username;
            smtpClient_ =
                new SmtpClient(_smtpServer, _port)
                {
                    Credentials = new NetworkCredential(_username, _password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = _enableSsl
                };
        }

        public void SendEmail(string _recipient, string _subject, string _content)
        {
            if (string.IsNullOrEmpty(_recipient))
                throw new ArgumentException("Odbiorca nie może być pusty!");

            var message = new MailMessage(sender_, _recipient, _subject, _content);
            smtpClient_.Send(message);
        }
    }
}