using System.Linq;
using System.Web.Mvc;
using Gym_Management_System_MVC.Models; 
namespace Gym_Management_System_MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly GYM_ManagmentEntities db = new GYM_ManagmentEntities();

        // GET: Dashboard
        public ActionResult Index()
        {
            // جلب آخر 5 أعضاء مسجلين (مرتبين من الأحدث إلى الأقدم)
            var recentMembers = db.Members
                                  .OrderByDescending(m => m.Id) // ترتيب تنازلي حسب الـ ID (أو تاريخ التسجيل لو متوفر)
                                  .Take(5) // جلب آخر 5 فقط
                                  .ToList();

            // جلب أسماء كل المدربين
            var coaches = db.Coaches
                            .Select(c => c.Name) // جلب أسماء المدربين فقط
                            .ToList();

            // إرسال البيانات إلى الـ View باستخدام ViewBag
            ViewBag.RecentMembers = recentMembers;
            ViewBag.Coaches = coaches;

            return View();
        }
    }
}
