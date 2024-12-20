using System.Linq;
using System.Web.Mvc;
using Gym_Management_System_MVC.Models;

public class MemberController : Controller
{
    private GYM_ManagmentEntities db = new GYM_ManagmentEntities();

    // أكشن لعرض الأعضاء
    public ActionResult Index()
    {
        var members = db.Members.ToList();
        return View(members);
    }

    // أكشن لإضافة عضو جديد
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost] // POST request
    public ActionResult Create(Member member)
    {
        if (ModelState.IsValid) // التحقق من صحة البيانات المدخلة
        {
            _ = db.Members.Add(member); // إضافة العضو إلى الـ DbContext
            db.SaveChanges(); // حفظ التغييرات
            return RedirectToAction("Index"); // إعادة التوجيه إلى صفحة عرض الأعضاء
        }

        return View(member); // في حالة وجود خطأ في البيانات، نعرض نموذج الإضافة مرة أخرى
    }
    public ActionResult Edit(Guid id)
    {
        var member = db.Members.Find(id);
        if (member == null)
        {
            return HttpNotFound(); // إذا كان العضو مش موجود
        }
        return View(member); // عرض بيانات العضو في الفورم
    }

    // حفظ التعديلات بعد إرسال الفورم
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Member member)
    {
        if (ModelState.IsValid)
        {
            db.Entry(member).State = System.Data.Entity.EntityState.Modified; // تعديل حالة الكائن
            db.SaveChanges(); // حفظ التعديلات في قاعدة البيانات
            return RedirectToAction("Index"); // إعادة توجيه الصفحة الرئيسية بعد التعديل
        }
        return View(member); // إذا كان في خطأ في البيانات، إعادة عرض الفورم مع الأخطاء

        [HttpPost("{memberId}/AddMembership")]
    public async Task<IActionResult> AddMembership(Guid memberId, [FromBody] AddMembershipDto dto)
    {
        // التحقق من وجود العضو
        var member = await _context.Members.FindAsync(memberId);
        if (member == null)
            return NotFound("Member not found");

        // التحقق من وجود العضوية
        var membership = await _context.Memberships.FindAsync(dto.MembershipID);
        if (membership == null)
            return NotFound("Membership not found");

        // التأكد من أن تاريخ انتهاء العضوية في المستقبل
        if (dto.ExpiryDate <= DateTime.Now)
            return BadRequest("Expiry date must be in the future");

        // إضافة العلاقة بين العضو والعضوية
        var memberHasMembership = new MemberHasMembership
        {
            MemberID = memberId,
            MembershipID = dto.MembershipID,
            ExpiryDate = dto.ExpiryDate,
            JoinDate = DateTime.Now
        };

        _context.MemberHasMemberships.Add(memberHasMembership);
        await _context.SaveChangesAsync();

        return Ok("Membership added successfully.");
        return View("Membership", memberHasMembership);


    }

}
