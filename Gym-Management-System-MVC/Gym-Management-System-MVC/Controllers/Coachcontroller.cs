using Gym_Management_System_MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

public class CoachController : Controller
{
    private GYM_ManagmentEntities db = new GYM_ManagmentEntities(); // تعريف الـ DbContext للتعامل مع قاعدة البيانات

    // عرض قائمة المدربين
    public ActionResult Index()
    {
        var coaches = db.Coaches.ToList(); // جلب جميع المدربين من قاعدة البيانات
        ViewBag.ShowNav = true;
        return View(coaches); // إرسال المدربين إلى الـ View
    }

    // عرض نموذج إضافة مدرب جديد
    public ActionResult Create()
    {
        ViewBag.ShowNav = true;
        return Index();
    }

    [HttpPost]
    public ActionResult Create(Coach coach)
    {
        if (ModelState.IsValid)
        {
            db.Coaches.Add(coach); // إضافة المدرب إلى قاعدة البيانات
            db.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
            return RedirectToAction("Index"); // إعادة التوجيه إلى صفحة المدربين بعد الإضافة
        }
        ViewBag.ShowNav = true;
        return View(coach);
    }

    // عرض نموذج تعديل بيانات مدرب
    public ActionResult Edit(Guid id)
    {
        var coach = db.Coaches.Find(id); // البحث عن المدرب باستخدام الـ ID
        if (coach == null)
        {
            return HttpNotFound(); // في حالة عدم العثور على المدرب
        }
        ViewBag.ShowNav = true;
        return View(coach); // عرض بيانات المدرب في النموذج
    }
    
    [HttpPost]
    public ActionResult Edit(Coach coach)
    {
        if (ModelState.IsValid)
        {
            db.Entry(coach).State = System.Data.Entity.EntityState.Modified; // تحديث حالة المدرب إلى "معدل"
            db.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
            return RedirectToAction("Index"); // إعادة التوجيه إلى صفحة المدربين بعد التعديل
        }
        ViewBag.ShowNav = true;
        return View(coach);
    }

    // عرض نموذج حذف مدرب
    public ActionResult Delete(Guid id)
    {
        var coach = db.Coaches.Find(id); // البحث عن المدرب باستخدام الـ ID
        if (coach == null)
        {
            return HttpNotFound(); // في حالة عدم العثور على المدرب
        }
        ViewBag.ShowNav = true;
        return View(coach); // عرض بيانات المدرب في النموذج
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(Guid id)
    {
        var coach = db.Coaches.Find(id); // البحث عن المدرب باستخدام الـ ID
        if (coach == null)
        {
            return HttpNotFound(); // في حالة عدم العثور على المدرب
        }

        db.Coaches.Remove(coach); // حذف المدرب من قاعدة البيانات
        db.SaveChanges(); // حفظ التغييرات في قاعدة البيانات

        return RedirectToAction("Index"); // إعادة التوجيه إلى صفحة المدربين بعد الحذف
    }
}
