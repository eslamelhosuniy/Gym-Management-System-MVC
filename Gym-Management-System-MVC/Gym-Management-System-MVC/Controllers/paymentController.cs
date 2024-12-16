using Gym_Management_System_MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

public class PaymentController : Controller
{
    private GYM_ManagmentEntities db = new GYM_ManagmentEntities();

    // عرض كل المدفوعات
    public ActionResult Index()
    {
        var payments = db.Payments.ToList();
        return View(payments);
    }

    // عرض تفاصيل الدفع
    public ActionResult Details(Guid id)
    {
        var payment = db.Payments.Find(id);
        if (payment == null)
        {
            return HttpNotFound();
        }
        return View(payment);
    }

    // إضافة عملية دفع جديدة
    public ActionResult Create()
    {
        ViewBag.MemberID = new SelectList(db.Members, "MemberID", "Name"); // قائمة الأعضاء
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Payment payment)
    {
        if (ModelState.IsValid)
        {
            payment.PaymentID = Guid.NewGuid(); // توليد ID جديد
            payment.Date = System.DateTime.Now; // تعيين تاريخ الدفع الحالي
            db.Payments.Add(payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.MemberID = new SelectList(db.Members, "MemberID", "Name", payment.MemberID);
        return View(payment);
    }

    // تعديل بيانات عملية دفع
    public ActionResult Edit(Guid id)
    {
        var payment = db.Payments.Find(id);
        if (payment == null)
        {
            return HttpNotFound();
        }
        ViewBag.MemberID = new SelectList(db.Members, "MemberID", "Name", payment.MemberID);
        return View(payment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Payment payment)
    {
        if (ModelState.IsValid)
        {
            db.Entry(payment).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.MemberID = new SelectList(db.Members, "MemberID", "Name", payment.MemberID);
        return View(payment);
    }

    // حذف عملية دفع
    public ActionResult Delete(Guid id)
    {
        var payment = db.Payments.Find(id);
        if (payment == null)
        {
            return HttpNotFound();
        }
        return View(payment);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(Guid id)
    {
        var payment = db.Payments.Find(id);
        db.Payments.Remove(payment);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
