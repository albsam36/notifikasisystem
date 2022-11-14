using Form.Data;
using Form.Models;
using Form.Models.Domain;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Form.Controllers
{
    public class IDCardformController : Controller
    {
        private readonly FormDBContext formDBContext;
        private readonly IHostingEnvironment hostingEnvironment;

        public IDCardformController(FormDBContext formDBContext, IHostingEnvironment environment)
        {
            this.formDBContext = formDBContext;
            hostingEnvironment = environment;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Addemployee addemployeeRequest)
        {

            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                EventName = addemployeeRequest.EventName,
                NamaVendor = addemployeeRequest.NamaVendor,
                No_Kontak = addemployeeRequest.No_Kontak,
                Periode = addemployeeRequest.Periode,
                nilai = addemployeeRequest.nilai,
                selesai = addemployeeRequest.selesai,




            };


            await formDBContext.Employees.AddAsync(employee);
            await formDBContext.SaveChangesAsync();
            return RedirectToAction("Add");




        }
        [HttpGet]
        public async Task<IActionResult> Check()
        {

            var employees = formDBContext.Employees.Where(x => x.nilai == "0").ToList();
            foreach ( var item in employees)
            {
                var durasi = item.Periode.Subtract(DateTime.Now);
                if ( durasi.Days < 184)
                {
                    item.nilai = "1";
                    formDBContext.SaveChanges();
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.IsBodyHtml = true;
                    mailMessage.From = new MailAddress("Pertamina@gmail.com");
                    mailMessage.To.Add(new MailAddress("acalbertsamuel123@gmail.com"));
                    mailMessage.Subject = "Notifikasi Kontrak kurang dari 6 Bulan";
                    mailMessage.Body = "Kontrak dengan Nama :" + item.EventName +
                        "<br /> Vendor  :" + item.NamaVendor +
                        "<br /> Kontrak dengan No :" + item.No_Kontak +
                        "<br /> Tinggal memiliki waktu selama  : " + durasi.Days + " Hari" +
                        "<br/> tekan link untuk menyudahkan notifikasi : https://localhost:7162/IDCardform/Confirmation/"+ item.Id; 
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("albert.samuel.work@gmail.com", "ajkcbktsiqoexslr"); // Enter seders User name and password  
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                }
            }
            return Json(true);


        }
        public async Task<IActionResult> Check3()
        {

            var employees = formDBContext.Employees.Where(x => x.nilai == "1" && x.selesai == "no").ToList();
            foreach (var item in employees)
            {
                var durasi = item.Periode.Subtract(DateTime.Now);
                if (durasi.Days < 184)
                {
                    item.nilai = "2";
                    item.selesai = "yes";
                    formDBContext.SaveChanges();
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.IsBodyHtml = true;
                    mailMessage.From = new MailAddress("Pertamina@gmail.com");
                    mailMessage.To.Add(new MailAddress("acalbertsamuel123@gmail.com"));
                    mailMessage.Subject = "Notifikasi Kontrak kurang dari 3 Bulan";
                    mailMessage.Body = "Kontrak dengan Nama :" + item.EventName +
                        "<br /> Vendor  :" + item.NamaVendor +
                        "<br /> Kontrak dengan No :" + item.No_Kontak +
                        "<br /> Tinggal memiliki waktu selama  : " + durasi.Days + " Hari";
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("albert.samuel.work@gmail.com", "ajkcbktsiqoexslr"); // Enter seders User name and password  
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                }
            }
            return Json(true);




        }
        public async Task<IActionResult> History()
        {

            var employees = await formDBContext.Employees.ToListAsync();
            return View(employees);




        }
        public async Task<IActionResult> Confirmation(Guid Id)
        {

            var Employee = formDBContext.Employees.ToList().Find(x => x.Id.Equals(Id));
            Employee.selesai = "yes";
            formDBContext.SaveChanges();
            return Json(true);




        }



    }
}
