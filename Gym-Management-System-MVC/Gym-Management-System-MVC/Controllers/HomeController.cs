using System.Web.Mvc;

public class HomeController : Controller
{
    // الصفحة الرئيسية أو لوحة التحكم
    public ActionResult Index()
    {
        return View(); // عرض الصفحة الرئيسية
    }
    HttpPost]
    public IActionResult Login(string username, string password)
    {
        // بيانات للمقارنة (مثال)
        string validUsername = "admin";
        string validPassword = "12345";

        if (username == validUsername && password == validPassword)
        {
            // لو البيانات صحيحة
            return RedirectToAction("Dashboard");
        }
        else
        {
            // لو البيانات غلط، نعرض رسالة خطأ
            ViewBag.ErrorMessage = "اسم المستخدم أو كلمة المرور غير صحيحة!";
            return View("Index");
        }
    }

    // صفحة لوحة التحكم
    public IActionResult Dashboard()
    {
        return View(); // عرض صفحة لوحة التحكم
    }
}
