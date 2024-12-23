using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Gym_Management_System_MVC.Models;

public class MemberController : Controller
{
    private GYM_ManagmentEntities db = new GYM_ManagmentEntities();

    // أكشن لعرض الأعضاء
    public ActionResult Index()
    {
        var members = db.Members.ToList();
        ViewBag.ShowNav = true;
        return View(members);
    }

    // أكشن لإضافة عضو جديد
    public ActionResult Create()
    {
        ViewBag.ShowNav = true;
        return View();
    }

    [HttpPost] // POST request
    public ActionResult Create(Member member)
    {
        if (ModelState.IsValid) // التحقق من صحة البيانات المدخلة
        {
            _ = db.Members.Add(member); // إضافة العضو إلى الـ DbContext
            db.SaveChanges(); // حفظ التغييرات
            ViewBag.ShowNav = true;
            return RedirectToAction("Index"); // إعادة التوجيه إلى صفحة عرض الأعضاء
        }
        ViewBag.ShowNav = true;
        return View(member); // في حالة وجود خطأ في البيانات، نعرض نموذج الإضافة مرة أخرى
    }
    public ActionResult Edit(System.Guid id)
    {
        var member = db.Members.Find(id);
        if (member == null)
        {
            return HttpNotFound(); // إذا كان العضو مش موجود
        }
        ViewBag.ShowNav = true;
        return View(member); // عرض بيانات العضو في الفورم
    }

    // حفظ التعديلات بعد إرسال الفورم
    [HttpPost]

    public ActionResult Edit(Member member)
    {
        if (ModelState.IsValid)
        {
            db.Entry(member).State = System.Data.Entity.EntityState.Modified; // تعديل حالة الكائن
            db.SaveChanges(); // حفظ التعديلات في قاعدة البيانات
            return RedirectToAction("Index"); // إعادة توجيه الصفحة الرئيسية بعد التعديل
        }
        ViewBag.ShowNav = true;
        return View(member); // إذا كان في خطأ في البيانات، إعادة عرض الفورم مع الأخطاء
    }
}

