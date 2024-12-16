using Gym_Management_System_MVC.Models;

using System;
using System.Linq;
using System.Web.Mvc;

public class MemberHasMembershipController : Controller
{
    private GYM_ManagmentEntities db = new GYM_ManagmentEntities ();

    public ActionResult Index()
    {
        var memberHasMembership = db.MemberHasMemberships.ToList();
        return View(memberHasMembership);
    }

    public ActionResult Create()
    {
        ViewBag.Members = db.Members.ToList();
        ViewBag.Memberships = db.Memberships.ToList();
        return View();
    }

    [HttpPost]
    public ActionResult Create(MemberHasMembership memberHasMembership)
    {
        if (ModelState.IsValid)
        {
            db.MemberHasMemberships.Add(memberHasMembership);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(memberHasMembership);
    }

    public ActionResult Delete(Guid memberId, int membershipId)
    {
        var relation = db.MemberHasMemberships.Find(memberId, membershipId);
        if (relation != null)
        {
            db.MemberHasMemberships.Remove(relation);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
