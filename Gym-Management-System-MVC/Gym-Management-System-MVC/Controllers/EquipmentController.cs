using Gym_Management_System_MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

public class EquipmentController : Controller
{
    private GYM_ManagmentEntities db = new GYM_ManagmentEntities();
   
    // عرض كل الأجهزة الرياضية
    public ActionResult Index()
    {
        var equipmentList = db.Equipments.ToList();
        return View(equipmentList);
    }

    // عرض تفاصيل جهاز رياضي
    public ActionResult Details(Guid id)
    {
        var equipment = db.Equipments.Find(id);
        if (equipment == null)
        {
            return HttpNotFound();
        }
        return View(equipment);
    }

    // إضافة جهاز جديد
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Equipment equipment)
    {
        if (ModelState.IsValid)
        {
            equipment.EquipmentID = Guid.NewGuid(); // توليد ID جديد
            equipment.PurchaseDate = System.DateTime.Now; // تعيين تاريخ الشراء الحالي
            db.Equipments.Add(equipment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(equipment);
    }

    // تعديل بيانات جهاز
    public ActionResult Edit(Guid id)
    {
        var equipment = db.Equipments.Find(id);
        if (equipment == null)
        {
            return HttpNotFound();
        }
        return View(equipment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Equipment equipment)
    {
        if (ModelState.IsValid)
        {
            db.Entry(equipment).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(equipment);
    }

    // حذف جهاز
    public ActionResult Delete(Guid id)
    {
        var equipment = db.Equipments.Find(id);
        if (equipment == null)
        {
            return HttpNotFound();
        }
        return View(equipment);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(Guid id)
    {
        var equipment = db.Equipments.Find(id);
        db.Equipments.Remove(equipment);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
