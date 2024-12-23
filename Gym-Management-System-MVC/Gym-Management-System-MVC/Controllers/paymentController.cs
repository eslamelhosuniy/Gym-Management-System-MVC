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
        ViewBag.ShowNav = true;

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
        ViewBag.ShowNav = true;

        return View(payment);
    }

    // إضافة عملية دفع جديدة
    public ActionResult Create()
    {
        ViewBag.MemberID = new SelectList(db.Members, "MemberID", "Name"); // قائمة الأعضاء
        ViewBag.ShowNav = true;

        return View();
    }

    public Member SearchByMemberPhone(string MemberPhone)
    {
        Member Member = db.Members.Find(MemberPhone);
        return Member;
    }

    [HttpPost]

    public ActionResult Create(Payment payment, string MemberPhone)
    {
        if (ModelState.IsValid)
        {
            Member Member = SearchByMemberPhone(MemberPhone);
            payment.MemberID = Member.MemberID;
            payment.Member = Member;
            payment.PaymentID = Guid.NewGuid(); // توليد ID جديد
            payment.Date = System.DateTime.Now; // تعيين تاريخ الدفع الحالي
            db.Payments.Add(payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.MemberID = new SelectList(db.Members, "MemberID", "Name", payment.MemberID);
        ViewBag.ShowNav = true;

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
        ViewBag.ShowNav = true;

        return View(payment);
    }

    [HttpPost]

    public ActionResult Edit(Payment payment)
    {
        if (ModelState.IsValid)
        {
            db.Entry(payment).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.MemberID = new SelectList(db.Members, "MemberID", "Name", payment.MemberID);
        ViewBag.ShowNav = true;

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
        ViewBag.ShowNav = true;

        return View(payment);
    }

    [HttpPost, ActionName("Delete")]

    public ActionResult DeleteConfirmed(Guid id)
    {
        var payment = db.Payments.Find(id);
        db.Payments.Remove(payment);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
