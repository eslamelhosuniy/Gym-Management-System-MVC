using System.Linq;
using System.Web.Mvc;
using Gym_Management_System_MVC.Models;

public class MemberController : Controller
{
    private GYM_ManagmentEntities db = new GYM_ManagmentEntities();

    // أكشن لعرض الأعضاء
    public ActionResult Index()
    {
        var members = db.Members.ToList();
        return View(members);
    }

    // أكشن لإضافة عضو جديد
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost] // POST request
    public ActionResult Create(Member member)
    {
        if (ModelState.IsValid) // التحقق من صحة البيانات المدخلة
        {
            _ = db.Members.Add(member); // إضافة العضو إلى الـ DbContext
            db.SaveChanges(); // حفظ التغييرات
            return RedirectToAction("Index"); // إعادة التوجيه إلى صفحة عرض الأعضاء
        }

        return View(member); // في حالة وجود خطأ في البيانات، نعرض نموذج الإضافة مرة أخرى
    }
}
