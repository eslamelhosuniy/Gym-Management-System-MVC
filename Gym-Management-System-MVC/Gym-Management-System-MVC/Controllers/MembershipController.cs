using GymManagementSystem.Models; // استيراد الموديل
using System.Linq;
using System.Web.Mvc;

public class MembershipController : Controller
{
    private GymManagementDB db = new GymManagementDB();

    // عرض كل العضويات
    public ActionResult Index()
    {
        var memberships = db.Memberships.ToList();
        return View(memberships);
    }

    // عرض تفاصيل عضوية
    public ActionResult Details(int id)
    {
        var membership = db.Memberships.Find(id);
        if (membership == null)
        {
            return HttpNotFound();
        }
        return View(membership);
    }

    // إضافة عضوية جديدة
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Membership membership)
    {
        if (ModelState.IsValid)
        {
            db.Memberships.Add(membership);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
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
        return View(membership);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Membership membership)
    {
        if (ModelState.IsValid)
        {
            db.Entry(membership).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
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
        return View(membership);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var membership = db.Memberships.Find(id);
        db.Memberships.Remove(membership);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
