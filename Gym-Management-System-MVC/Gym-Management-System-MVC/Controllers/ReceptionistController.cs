using Gym_Management_System_MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

public class ReceptionistController : Controller
{
    private GymManagementDB db = new GymManagementDB();

    // عرض كل موظفي الاستقبال
    public ActionResult Index()
    {
        var receptionists = db.Receptionists.ToList();
        return View(receptionists);
    }

    // عرض تفاصيل موظف استقبال
    public ActionResult Details(Guid id)
    {
        var receptionist = db.Receptionists.Find(id);
        if (receptionist == null)
        {
            return HttpNotFound();
        }
        return View(receptionist);
    }

    // إضافة موظف استقبال جديد
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Receptionist receptionist)
    {
        if (ModelState.IsValid)
        {
            receptionist.ReceptionistID = Guid.NewGuid(); // توليد ID جديد
            db.Receptionists.Add(receptionist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(receptionist);
    }

    // تعديل بيانات موظف استقبال
    public ActionResult Edit(Guid id)
    {
        if (db.Receptionists.Find(id) == null)
        {
            return HttpNotFound();
        }
        return View(db.Receptionists.Find(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Receptionist receptionist)
    {
        if (ModelState.IsValid)
        {
            db.Entry(receptionist).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(receptionist);
    }

    // حذف موظف استقبال
    public ActionResult Delete(Guid id)
    {
        var receptionist = db.Receptionists.Find(id);
        if (receptionist == null)
        {
            return HttpNotFound();
        }
        return View(receptionist);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(Guid id)
    {
        var receptionist = db.Receptionists.Find(id);
        object value = db.Receptionists.Remove(receptionist);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
