using Gym_Management_System_MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

public class TrackEquipmentController : Controller
{
    private GymManagementDB db = new GymManagementDB();

    public ActionResult Index()
    {
        var trackEquipment = db.TrackEquipment.ToList();
        return View(trackEquipment);
    }

    public ActionResult Create()
    {
        ViewBag.Receptionists = db.Receptionists.ToList();
        ViewBag.Equipments = db.Equipments.ToList();
        return View();
    }

    [HttpPost]
    public ActionResult Create(TrackEquipment trackEquipment)
    {
        if (ModelState.IsValid)
        {
            db.TrackEquipment.Add(trackEquipment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(trackEquipment);
    }

    public ActionResult Delete(Guid receptionistId, Guid equipmentId)
    {
        var relation = db.TrackEquipment.Find(receptionistId, equipmentId);
        if (relation != null)
        {
            db.TrackEquipment.Remove(relation);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
