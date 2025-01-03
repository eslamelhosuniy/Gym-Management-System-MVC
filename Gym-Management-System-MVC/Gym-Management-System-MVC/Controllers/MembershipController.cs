﻿using Gym_Management_System_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

public class MembershipController : Controller
{
    private GYM_ManagmentEntities db = new GYM_ManagmentEntities();

    // عرض كل العضويات
    public ActionResult plans()
    {
        //var memberships = db.Memberships.ToList();
        var testCoaches = new List<Membership>
    {
        new Membership {  Type = "Fitness", Cost = 12 },
        new Membership {  Type = "Yoga", Cost = 12 },
        new Membership {  Type = "Strength Training", Cost =12}
    };
        ViewBag.ShowNav = true;

        return View(testCoaches);
    }

    // عرض تفاصيل عضوية
    public ActionResult Details(int id)
    {
        var membership = db.Memberships.Find(id);
        if (membership == null)
        {
            return HttpNotFound();
        }
        ViewBag.ShowNav = true;

        return View(membership);
    }

    // إضافة عضوية جديدة
    public ActionResult Create()
    {
        ViewBag.ShowNav = true;

        return View();

    }

    [HttpPost]

    public ActionResult Create(Membership membership)
    {
        if (ModelState.IsValid)
        {
            db.Memberships.Add(membership);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.ShowNav = true;

        return View(membership);
    }

    // تعديل بيانات عضوية
    public ActionResult Edit(int id)
    {
        var membership = db.Memberships.Find(id);
        if (membership == null)
        {
            return HttpNotFound();
        }
        ViewBag.ShowNav = true;

        return View(membership);
    }

    [HttpPost]

    public ActionResult Edit(Membership membership)
    {
        if (ModelState.IsValid)
        {
            db.Entry(membership).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.ShowNav = true;

        return View(membership);
    }

    // حذف عضوية
    public ActionResult Delete(int id)
    {
        var membership = db.Memberships.Find(id);
        if (membership == null)
        {
            return HttpNotFound();
        }
        ViewBag.ShowNav = true;

        return View(membership);
    }

    [HttpPost, ActionName("Delete")]

    public ActionResult DeleteConfirmed(int id)
    {
        var membership = db.Memberships.Find(id);
        db.Memberships.Remove(membership);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
