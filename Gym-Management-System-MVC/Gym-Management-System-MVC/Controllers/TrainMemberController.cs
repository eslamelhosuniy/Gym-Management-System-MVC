using Gym_Management_System_MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

public class TrainMemberController : Controller
{
    private GymManagementDB db = new GymManagementDB();

    public ActionResult Index()
    {
        var trainMember = db.TrainMember.ToList();
        return View(trainMember);
    }

    public ActionResult Create()
    {
        ViewBag.Coaches = db.Coaches.ToList();
        ViewBag.Members = db.Members.ToList();
        return View();
    }

    [HttpPost]
    public ActionResult Create(TrainMember trainMember)
    {
        if (ModelState.IsValid)
        {
            db.TrainMember.Add(trainMember);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(trainMember);
    }

    public ActionResult Delete(Guid coachId, Guid memberId)
    {
        var relation = db.TrainMember.Find(coachId, memberId);
        if (relation != null)
        {
            db.TrainMember.Remove(relation);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
