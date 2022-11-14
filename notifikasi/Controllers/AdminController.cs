using Form.Data;
using Form.Models;
using Form.Models.Domain;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Net.Http.Headers;
using System.Net.Mail;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Form.Controllers
{
    public class AdminController : Controller
    {
        private readonly FormDBContext formDBContext;
        private readonly IHostingEnvironment hostingEnvironment;

        public AdminController(FormDBContext formDBContext, IHostingEnvironment environment)
        {
            this.formDBContext = formDBContext;
            hostingEnvironment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await formDBContext.Employees.ToListAsync();
            return View(employees);
        }
        [HttpGet]
        public JsonResult GetbyID(Guid Id)
        {
            var Employee = formDBContext.Employees.ToList().Find(x => x.Id.Equals(Id));

            return Json(Employee);
        }
        [HttpPost]
        public IActionResult Update(Addemployee data)
        {
            
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("Pertamina@gmail.com");
            mailMessage.To.Add( new MailAddress("albertsamuel@gmail.com"));
            mailMessage.Subject = "Perpanjangan Kartu";
            mailMessage.Body = "Silahkan datang untuk perpanjangan jangkat waktu kartu";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("albert.samuel.work@gmail.com", "ajkcbktsiqoexslr"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);
            return View();
        }

      
        public IActionResult Download(Addemployee data)
        {


            return View();

        }
        public JsonResult Delete(Guid Id)
        {
            var Employee = formDBContext.Employees.ToList().Find(x => x.Id.Equals(Id));

            return Json(Employee);
        }
        public IActionResult Delete2(Addemployee data)
        {
           
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("Pertamina@gmail.com");
            mailMessage.To.Add(new MailAddress("asasmaksnajkbjhv@gmail.com"));
            mailMessage.Subject = "Penolakan Perpanjangan Kartu";
            mailMessage.Body = "Mohon maaf permintaan ditolak dikarenakan " + "karena";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("albert.samuel.work@gmail.com", "ajkcbktsiqoexslr"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);
            return View();
        }

        public async Task<IActionResult> History()
        {
            var employees = await formDBContext.Employees.ToListAsync();
            return View(employees);
        }


    }
}
