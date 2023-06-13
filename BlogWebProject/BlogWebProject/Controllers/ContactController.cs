using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogWebProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogWebProject.Controllers
{
    public class ContactController : BaseController
    {
        // GET: /<controller>/

        [HttpGet]
        public IActionResult Index()
        {
            string? message = TempData["Message"] as string;
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string email, string subject, string message)
        {
            try
            {
                // E-posta göndermek için SMTP ayarlarını yapılandırın
                SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("tolgaozkaya.2002@outlook.com", "tolga123"); // Mesaj gönder

                // Posta mesajını oluştur
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(email);
                mailMessage.To.Add("tolgaozkaya.2002@outlook.com"); //Mesaj al
                mailMessage.Subject = subject;
                mailMessage.Body = message;

                // Posta iletisini SMTP sunucusuna gönder
                smtpClient.Send(mailMessage);
                ViewBag.mesaj2 = "Giriş Başarılı";

                // Kullanıcıyı başarıyla gönderilen sayfaya yönlendir
                TempData["Message"] = " Mail başarılı bir şekilde gönderildi";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Redirect user to error page
                TempData["Message"] = " HATA - Mail Gönderilemedi..";
                return RedirectToAction("Index");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



