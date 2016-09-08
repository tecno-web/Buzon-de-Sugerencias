using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sugerencias.Models;
using System.Net.Mail;
using reCAPTCHA.MVC;

namespace Sugerencias.Controllers
{
    public class BuzonController : Controller
    {
        // GET: Buzon
        
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidator]
        public ActionResult Index([Bind(Include = "Nombre,Correo,Telefono,Sugerencia")] Models.EmailModelView email)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("josepe.pedraza@gmail.com", "October_2016");
                mail.From = new MailAddress("josepe.pedraza@gmail.com");
                mail.To.Add("joosepe.pedraza@gmail.com");
                mail.CC.Add("web@dss.com.bo");
                mail.Subject = String.Format("Sugerencia del Cliente: {0}", email.Nombre);
                mail.IsBodyHtml = true;
                mail.Body = String.Format("<strong>Email de Contancto: {0}</strong><br><strong>Telefono: {1}</strong><br><strong>Sugerencia/Reclamo/Queja: {2}</strong>", email.Correo, email.Telefono,email.Sugerencia);
                client.Send(mail);
                TempData["mensaje"] = "$(document).ready(function(){Materialize.toast($toastContent,2000,'rounded');});";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}