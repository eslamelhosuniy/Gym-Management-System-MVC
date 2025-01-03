﻿using Gym_Management_System_MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

public class ReceptionistController : Controller
{
    private GYM_ManagmentEntities db = new GYM_ManagmentEntities();

    // عرض كل موظفي الاستقبال
    public ActionResult Index()
    {
        //var receptionists = db.Receptionists.ToList();
        ViewBag.ShowNav = true;
        return View();
    }

    // إضافة موظف استقبال جديد
    public ActionResult Create()
    {
        ViewBag.ShowNav = true;
        return View();
    }

    [HttpPost]

    public ActionResult Create(Receptionist receptionist)
    {
        if (ModelState.IsValid)
        {
            receptionist.ReceptionistID = Guid.NewGuid(); // توليد ID جديد
            db.Receptionists.Add(receptionist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.ShowNav = true;
        return View(receptionist);
    }

    // تعديل بيانات موظف استقبال
    public ActionResult Edit(Guid id)
    {
        if (db.Receptionists.Find(id) == null)
        {
            return HttpNotFound();
        }
        ViewBag.ShowNav = true;
        return View(db.Receptionists.Find(id));
    }

    [HttpPost]

    public ActionResult Edit(Receptionist receptionist)
    {
        if (ModelState.IsValid)
        {
            db.Entry(receptionist).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.ShowNav = true;
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
        ViewBag.ShowNav = true;
        return View(receptionist);
    }

    [HttpPost, ActionName("Delete")]

    public ActionResult DeleteConfirmed(Guid id)
    {
        var receptionist = db.Receptionists.Find(id);
        object value = db.Receptionists.Remove(receptionist);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    // عرض تفاصيل موظف استقبال
    public ActionResult Details(Guid id)
    {
        var receptionist = db.Receptionists.Find(id);
        if (receptionist == null)
        {
            return HttpNotFound();
        }
        ViewBag.ShowNav = true;
        return View(receptionist);
    }
    // حفظ التغييرات في قاعدة البيانات
    public ActionResult SaveChanges()
    {
        try
        {
            db.SaveChanges(); // حفظ التغييرات
            TempData["SuccessMessage"] = "تم الحفظ بنجاح!";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"حدث خطأ أثناء الحفظ: {ex.Message}";
        }
        return RedirectToAction("Index");
    }
}

