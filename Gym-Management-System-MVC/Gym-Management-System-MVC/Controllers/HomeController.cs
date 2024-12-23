using Gym_Management_System_MVC.Models;
using System.Web.Mvc;
using System.Linq;

public class HomeController : Controller
{
    private GYM_ManagmentEntities db = new GYM_ManagmentEntities();

    // الصفحة الرئيسية أو لوحة التحكم
    public ActionResult landingPage()
    {
        return View(); // عرض الصفحة الرئيسية
    }
      public ActionResult Login()
    {
        return View(); // عرض الصفحة الرئيسية
    }
  
    public interface IActionResult
    {
    }


    [HttpPost]
    public ActionResult Logining(string mail, string password)
    {
        // بيانات للمقارنة (مثال)
        string validMail = "admin123@gmail.com";
        string validPassword = "12345";

        // البحث عن المستخدم بالبريد الإلكتروني
        Receptionist receptionist = db.Receptionists.FirstOrDefault(r => r.Email == mail);


        // التحقق من الحقول
        if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password))
        {
            ViewBag.ErrorMessage = "البريد الإلكتروني وكلمة المرور مطلوبان!";
            return View("Index");
        }

        // التحقق من صحة البيانات
        if ((mail == validMail && password == validPassword) ||
            (receptionist != null && receptionist.PasswordHash == password))
        {
            // لو البيانات صحيحة
            return RedirectToAction("Index", "Dashboard");
        }
        else
        {
            // لو البيانات خاطئة
            ViewBag.ErrorMessage = "اسم المستخدم أو كلمة المرور غير صحيحة!";
            return View("Index");
        }
    }




}
