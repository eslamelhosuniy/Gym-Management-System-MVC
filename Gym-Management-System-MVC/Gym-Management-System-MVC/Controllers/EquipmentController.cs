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

    public async Task<IActionResult> AssignEquipmentToReceptionist(Guid receptionistId, Guid equipmentId)
    {
        // جلب Receptionist من الـ DB بناءً على الـ receptionistId
        var receptionist = await _context.Receptionists
            .FirstOrDefaultAsync(r => r.ReceptionistID == receptionistId);

        // جلب الـ Equipment بناءً على الـ equipmentId
        var equipment = await _context.Equipments
            .FirstOrDefaultAsync(e => e.EquipmentID == equipmentId);

        if (receptionist != null && equipment != null)
        {
            // ربط الـ Equipment بالـ Receptionist (بإضافته إلى مجموعة الـ Equipments الخاصة بـ Receptionist)
            receptionist.Equipments.Add(equipment);

            // حفظ التغييرات في قاعدة البيانات
            await _context.SaveChangesAsync();

            // إعادة توجيه إلى صفحة عرض البيانات أو صفحة أخرى
            return RedirectToAction("Index", new { receptionistId });
        }

        return NotFound("Receptionist or Equipment not found.");
    }
   
  }
}
