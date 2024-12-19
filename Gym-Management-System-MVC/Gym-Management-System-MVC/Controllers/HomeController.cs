using System.Web.Mvc;

public class HomeController : Controller
{
    // الصفحة الرئيسية أو لوحة التحكم
    public ActionResult DashBoard()
    {
        ViewBag.ShowNav = false;
        return View(); // عرض الصفحة الرئيسية
    }
    public ActionResult landingPage()
    {
        ViewBag.ShowNav = false;

        return View(); // عرض الصفحة الرئيسية
    }
    public ActionResult login()
    {
        ViewBag.ShowNav = false;

        return View(); // عرض الصفحة الرئيسية
    }
    public ActionResult nav()
    {
        ViewBag.ShowNav = false;

        return View(); // عرض الصفحة الرئيسية
    }
}
