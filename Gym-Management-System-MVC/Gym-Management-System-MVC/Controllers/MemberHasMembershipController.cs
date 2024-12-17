using Gym_Management_System_MVC.Models;

using System;
using System.Linq;
using System.Web.Mvc;

public class MemberHasMembershipController : Controller
{
    private GymManagementDB db = new GymManagementDB();

    public ActionResult Index()
    {
        var memberHasMembership = db.MemberHasMembership.ToList();
        return View(memberHasMembership);
    }

    public ActionResult Create()
    {
        ViewBag.Members = db.Members.ToList();
        ViewBag.Memberships = db.Membership.ToList();
        return View();
    }

    [HttpPost]
    public ActionResult Create(MemberHasMembership memberHasMembership)
    {
        if (ModelState.IsValid)
        {
            db.MemberHasMembership.Add(memberHasMembership);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(memberHasMembership);
    }

    public ActionResult Delete(Guid memberId, int membershipId)
    {
        var relation = db.MemberHasMembership.Find(memberId, membershipId);
        if (relation != null)
        {
            db.MemberHasMembership.Remove(relation);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
