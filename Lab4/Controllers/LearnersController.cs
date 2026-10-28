using Lab4.Data;
using Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Controllers;

public class LearnersController : Controller
{
    private readonly SchoolContext _context;
    public LearnersController(SchoolContext context) => _context = context;

    public async Task<IActionResult> Index() => View(await _context.Learners
        .AsNoTracking().Include(l => l.Major).OrderBy(l => l.LearnerID).ToListAsync());

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var learner = await _context.Learners.AsNoTracking().Include(l => l.Major)
            .Include(l => l.Enrollments).ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(l => l.LearnerID == id);
        if (learner == null) return NotFound();
        return View(learner);
    }

    public async Task<IActionResult> Create()
    {
        await PopulateMajors();
        return View(new Learner { EnrollmentDate = DateTime.Today });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FirstMidName,LastName,EnrollmentDate,MajorID")] Learner learner)
    {
        await ValidateMajor(learner.MajorID);
        if (ModelState.IsValid)
        {
            _context.Learners.Add(learner);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Đã thêm học viên.";
            return RedirectToAction(nameof(Index));
        }
        await PopulateMajors(learner.MajorID);
        return View(learner);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var learner = await _context.Learners.FindAsync(id);
        if (learner == null) return NotFound();
        await PopulateMajors(learner.MajorID);
        return View(learner);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("LearnerID,FirstMidName,LastName,EnrollmentDate,MajorID")] Learner learner)
    {
        if (id != learner.LearnerID) return NotFound();
        var existing = await _context.Learners.FindAsync(id);
        if (existing == null) return NotFound();
        await ValidateMajor(learner.MajorID);
        if (ModelState.IsValid)
        {
            existing.FirstMidName = learner.FirstMidName;
            existing.LastName = learner.LastName;
            existing.EnrollmentDate = learner.EnrollmentDate;
            existing.MajorID = learner.MajorID;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Learners.AnyAsync(l => l.LearnerID == id)) return NotFound();
                throw;
            }
            TempData["Success"] = "Đã cập nhật học viên.";
            return RedirectToAction(nameof(Index));
        }
        await PopulateMajors(learner.MajorID);
        return View(learner);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var learner = await _context.Learners.AsNoTracking().Include(l => l.Major)
            .Include(l => l.Enrollments).FirstOrDefaultAsync(l => l.LearnerID == id);
        if (learner == null) return NotFound();
        return View(learner);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        // Recheck on POST so the confirmation page cannot bypass the enrollment rule.
        var learner = await _context.Learners.Include(l => l.Major)
            .Include(l => l.Enrollments).FirstOrDefaultAsync(l => l.LearnerID == id);
        if (learner == null) return NotFound();
        if (learner.Enrollments.Any())
        {
            ModelState.AddModelError("", "Không thể xóa học viên đã có đăng ký học.");
            return View("Delete", learner);
        }
        _context.Learners.Remove(learner);
        await _context.SaveChangesAsync();
        TempData["Success"] = "Đã xóa học viên.";
        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateMajors(int? selected = null) =>
        ViewData["MajorID"] = new SelectList(await _context.Majors.AsNoTracking()
            .OrderBy(m => m.MajorName).ToListAsync(), "MajorID", "MajorName", selected);

    private async Task ValidateMajor(int id)
    {
        if (!await _context.Majors.AnyAsync(m => m.MajorID == id))
            ModelState.AddModelError("MajorID", "Vui lòng chọn ngành học hợp lệ.");
    }
}
