using System.Web.Mvc;

public class HomeController : Controller
{
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
    public IActionResult Login(string mail, string password)
    {
        // بيانات للمقارنة (مثال)
        string validmail = "admin123@gmail.com";
        string validPassword = "12345";

        if (mail == validmail && password == validPassword)
        {
            // لو البيانات صحيحة
            return (IActionResult)RedirectToAction("Dashboard");
        }
        else
        {
            // لو البيانات غلط، نعرض رسالة خطأ
            ViewBag.ErrorMessage = "اسم المستخدم أو كلمة المرور غير صحيحة!";
            return (IActionResult)View("Index");
        }
    }

    // صفحة لوحة التحكم
    public IActionResult Dashboard()
    {
        return (IActionResult)View(); // عرض صفحة لوحة التحكم
    }
}
