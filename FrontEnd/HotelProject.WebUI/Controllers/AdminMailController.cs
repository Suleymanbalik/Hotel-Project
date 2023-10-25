using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();

            //This Part shows a Mail From Whom
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin","balksuleyman@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            //This Part shows a Mail to Who
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            //This part Hold the Messageboyd which means our mail
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.MailBody;           
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            //This part Hold te message subject
            mimeMessage.Subject = model.Mailsubject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("balksuleyman@gmail.com", "vesojunqjsolkbck");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index");
        }
    }
}
