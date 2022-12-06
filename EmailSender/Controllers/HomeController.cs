using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EmailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("shalala.shafiyeva23@gmail.com"));
            email.To.Add(MailboxAddress.Parse("shalala.shafiyeva23@gmail.com"));
            email.Subject = "Hello Message";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587);
            smtp.Authenticate("shalala.shafiyeva23@gmail.com", "julnvkdbnafxteqx");
            smtp.Send(email);
            smtp.Disconnect(true);
            //Вывод содержимого сообщения в консоли
            Console.WriteLine(email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body });
            return Ok();
        }
         
    }
}
