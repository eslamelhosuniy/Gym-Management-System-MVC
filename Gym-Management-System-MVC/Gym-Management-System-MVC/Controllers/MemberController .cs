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
    public ActionResult LoginAndDashboard(string email, string password)
    {
        // تحقق من صحة البريد الإلكتروني وكلمة السر
        var member = db.Members.FirstOrDefault(m => m.Email == email && m.Password == password);

        if (member == null)
        {
            // إذا كانت البيانات غير صحيحة، يتم إضافة رسالة خطأ
            TempData["ErrorMessage"] = "البريد الإلكتروني أو كلمة المرور غير صحيحة. من فضلك حاول مرة أخرى.";
            return RedirectToAction("Login"); // إعادة التوجيه إلى صفحة تسجيل الدخول
        }

        // إذا كانت البيانات صحيحة، نقوم بعرض بيانات العضو
        var coaches = db.Coaches.Where(c => c.MemberId == member.Id).ToList();
        var trainings = db.Trainings.Where(t => t.MemberId == member.Id).ToList();

        var model = new MemberDashboardViewModel
        {
            Member = member,
            Coaches = coaches,
            Trainings = trainings
        };

        return View("Dashboard", model); // عرض صفحة البيانات الخاصة بالعضو
    }

}

}
