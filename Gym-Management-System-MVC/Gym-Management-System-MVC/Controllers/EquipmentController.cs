using Gym_Management_System_MVC.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

public class EquipmentController : Controller
{
    private GYM_ManagmentEntities db = new GYM_ManagmentEntities();
   
    // عرض كل الأجهزة الرياضية
    public ActionResult Index()
    {
        var equipmentList = db.Equipments.ToList();
        ViewBag.ShowNav = true;
        return View(equipmentList);
    }

    // إضافة جهاز جديد
    public ActionResult Create()
    {
        ViewBag.ShowNav = true;
        return View();
    }

    [HttpPost]
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
        ViewBag.ShowNav = true;
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
        ViewBag.ShowNav = true;
        return View(equipment);
    }

    [HttpPost]

    public ActionResult Edit(Equipment equipment)
    {
        if (ModelState.IsValid)
        {
            db.Entry(equipment).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.ShowNav = true;
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
        ViewBag.ShowNav = true;
        return View(equipment);
    }

    public async Task<HomeController.IActionResult> AssignEquipmentToReceptionist(Guid receptionistId, Guid equipmentId)
    {
        // جلب Receptionist من الـ DB بناءً على الـ receptionistId
        var receptionist = await db.Receptionists
            .FirstOrDefaultAsync(r => r.ReceptionistID == receptionistId);

        // جلب الـ Equipment بناءً على الـ equipmentId
        var equipment = await db.Equipments
            .FirstOrDefaultAsync(e => e.EquipmentID == equipmentId);

        if (receptionist != null && equipment != null)
        {
            // ربط الـ Equipment بالـ Receptionist (بإضافته إلى مجموعة الـ Equipments الخاصة بـ Receptionist)
            receptionist.Equipments.Add(equipment);

            // حفظ التغييرات في قاعدة البيانات
            await db.SaveChangesAsync();

            // إعادة توجيه إلى صفحة عرض البيانات أو صفحة أخرى
            return (HomeController.IActionResult)RedirectToAction("Index", new { receptionistId });
        }

        return (HomeController.IActionResult)RedirectToAction("Index","Not Found");
    }

}
