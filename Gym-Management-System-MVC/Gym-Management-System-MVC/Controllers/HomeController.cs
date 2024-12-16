using System.Web.Mvc;

public class HomeController : Controller
{
    // الصفحة الرئيسية أو لوحة التحكم
    public ActionResult Index()
    {
        return View(); // عرض الصفحة الرئيسية
    }
}
