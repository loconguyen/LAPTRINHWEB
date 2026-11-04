using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class LearnerController(SchoolContext context) : Controller
{
    private const int PageSize = 8;

    public Task<IActionResult> Index(int? mid, string? keyword, int pageIndex = 1) => List(mid, keyword, pageIndex, false);
    public Task<IActionResult> LearnerFilter(int? mid, string? keyword, int pageIndex = 1) => List(mid, keyword, pageIndex, true);

    private async Task<IActionResult> List(int? mid, string? keyword, int pageIndex, bool partial)
    {
        keyword = keyword?.Trim();
        var query = context.Learners.AsNoTracking().Include(l => l.Major).AsQueryable();
        ViewBag.TotalLearners = await context.Learners.CountAsync();
        ViewBag.TotalMajors = await context.Majors.CountAsync();
        if (mid.HasValue) query = query.Where(l => l.MajorId == mid);
        if (!string.IsNullOrEmpty(keyword))
            query = query.Where(l => l.FirstMidName.Contains(keyword) || l.LastName.Contains(keyword) || (l.LastName + " " + l.FirstMidName).Contains(keyword));
        int total = await query.CountAsync();
        int pages = Math.Max(1, (int)Math.Ceiling(total / (double)PageSize));
        int page = Math.Clamp(pageIndex, 1, pages);
        ViewBag.pageNum = pages;
        ViewBag.pageIndex = page;
        ViewBag.mid = mid;
        ViewBag.keyword = keyword;
        ViewBag.Total = total;
        ViewBag.Majors = new SelectList(await context.Majors.AsNoTracking().OrderBy(m => m.MajorName).ToListAsync(), "MajorId", "MajorName", mid);
        var items = await query.OrderBy(l => l.LearnerId).Skip((page - 1) * PageSize).Take(PageSize).ToListAsync();
        return partial ? PartialView("LearnerTable", items) : View("Index", items);
    }

    public async Task<IActionResult> Details(int? id)
    {
        var learner = await context.Learners.AsNoTracking().Include(l => l.Major).Include(l => l.Enrollments).ThenInclude(e => e.Course).FirstOrDefaultAsync(l => l.LearnerId == id);
        return learner == null ? NotFound() : View(learner);
    }

    public async Task<IActionResult> Create()
    {
        await LoadMajors();
        return View(new Learner { EnrollmentDate = DateTime.Today });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FirstMidName,LastName,EnrollmentDate,MajorId")] Learner learner)
    {
        await ValidateMajor(learner);
        if (ModelState.IsValid)
        {
            learner.FirstMidName = learner.FirstMidName.Trim();
            learner.LastName = learner.LastName.Trim();
            context.Learners.Add(learner);
            await context.SaveChangesAsync();
            TempData["Success"] = "Đã thêm sinh viên thành công.";
            return RedirectToAction(nameof(Index));
        }
        await LoadMajors(learner.MajorId);
        return View(learner);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        var learner = await context.Learners.FindAsync(id);
        if (learner == null) return NotFound();
        await LoadMajors(learner.MajorId);
        return View(learner);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("LearnerId,FirstMidName,LastName,EnrollmentDate,MajorId")] Learner learner)
    {
        if (id != learner.LearnerId) return NotFound();
        var existing = await context.Learners.FindAsync(id);
        if (existing == null) return NotFound();
        await ValidateMajor(learner);
        if (ModelState.IsValid)
        {
            existing.FirstMidName = learner.FirstMidName.Trim();
            existing.LastName = learner.LastName.Trim();
            existing.EnrollmentDate = learner.EnrollmentDate;
            existing.MajorId = learner.MajorId;
            try { await context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { return NotFound(); }
            TempData["Success"] = "Đã cập nhật thông tin sinh viên.";
            return RedirectToAction(nameof(Index));
        }
        await LoadMajors(learner.MajorId);
        return View(learner);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        var learner = await context.Learners.AsNoTracking().Include(l => l.Major).FirstOrDefaultAsync(l => l.LearnerId == id);
        return learner == null ? NotFound() : View(learner);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var learner = await context.Learners.Include(l => l.Enrollments).FirstOrDefaultAsync(l => l.LearnerId == id);
        if (learner == null) return NotFound();
        context.Enrollments.RemoveRange(learner.Enrollments);
        context.Learners.Remove(learner);
        await context.SaveChangesAsync();
        TempData["Success"] = "Đã xóa sinh viên và các đăng ký học liên quan.";
        return RedirectToAction(nameof(Index));
    }

    private async Task LoadMajors(int? selected = null) => ViewBag.Majors = new SelectList(await context.Majors.AsNoTracking().OrderBy(m => m.MajorName).ToListAsync(), "MajorId", "MajorName", selected);
    private async Task ValidateMajor(Learner learner)
    {
        if (!await context.Majors.AnyAsync(m => m.MajorId == learner.MajorId))
            ModelState.AddModelError(nameof(learner.MajorId), "Vui lòng chọn chuyên ngành hợp lệ.");
    }
}
