using ECommercial.Bussiness.Abstract;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.AdministratorArea.Controllers
{
    public class MessagesController : Controller
    {
        private IContactService _contactService;
        private IEmailService _emailService;

        public MessagesController(IContactService contactService, IEmailService emailService)
        {
            _contactService = contactService;
            _emailService = emailService;
        }
        [HttpGet]
        public ActionResult IncomingMessages()
        {
            var result = _contactService.GetAll();
            return View(result.Data);
        }
        [HttpGet]
        public ActionResult ReadMessage(int Id)
        {
            var result = _contactService.GetById(Id);
            return View(result.Data);
        }
        [HttpGet]
        public ActionResult Reply(int Id)
        {
            var result = _contactService.GetById(Id);
            return View(result.Data);
        }
        [HttpPost]
        public ActionResult SendMail(Contact contact)
        {
            var mail = new Email
            {
                Title = contact.Title,
                Content = contact.Content,
                EmailDate = DateTime.Now,
                UserEmail = contact.UserEmail,
            };
            _emailService.Add(mail);
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(mail.UserEmail);
            mailMessage.From = new MailAddress("sercan.sever16@gmail.com");
            mailMessage.Subject = mail.Title;
            mailMessage.Body = "Sayın" + " " + contact.UserName + "," + "<br>" + mail.Content;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("sercan.sever16@gmail.com", "Cankan94");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            smtp.Send(mailMessage);
            return View();
        }
        [HttpGet]
        public ActionResult SentMessages()
        {
            var result = _emailService.GetAll();
            return View(result.Data);
        }
    }
}