using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Data;

public static class DbInitializer
{
    public static void Initialize(SchoolContext context)
    {
        context.Database.EnsureCreated();
        if (!context.Majors.Any())
        {
            context.Majors.AddRange(
                new Major { MajorName = "Information Technology" },
                new Major { MajorName = "Business Administration" },
                new Major { MajorName = "Computer Engineering" });
            context.SaveChanges();
        }
        if (!context.Learners.Any())
        {
            var majors = context.Majors.OrderBy(m => m.MajorID).ToList();
            context.Learners.AddRange(
                new Learner { FirstMidName = "Alexander", LastName = "Carson", EnrollmentDate = new DateTime(2024, 9, 1), MajorID = majors[0].MajorID },
                new Learner { FirstMidName = "Alonso", LastName = "Meredith", EnrollmentDate = new DateTime(2024, 9, 2), MajorID = majors[Math.Min(1, majors.Count - 1)].MajorID },
                new Learner { FirstMidName = "Anand", LastName = "Arturo", EnrollmentDate = new DateTime(2024, 9, 3), MajorID = majors[Math.Min(2, majors.Count - 1)].MajorID });
            context.SaveChanges();
        }
        // Add missing sample courses without replacing existing records.
        var courses = new[] {
            new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
            new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
            new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
        };
        foreach (var course in courses)
            if (!context.Courses.Any(c => c.CourseID == course.CourseID)) context.Courses.Add(course);
        context.SaveChanges();

        // Use the named sample learners, never arbitrary existing learners.
        var carson = context.Learners.FirstOrDefault(l => l.FirstMidName == "Alexander" && l.LastName == "Carson");
        var meredith = context.Learners.FirstOrDefault(l => l.FirstMidName == "Alonso" && l.LastName == "Meredith");
        AddSampleEnrollment(context, carson, 1050, 5.5);
        AddSampleEnrollment(context, carson, 4022, 7.5);
        AddSampleEnrollment(context, meredith, 1050, 3.5);
        AddSampleEnrollment(context, meredith, 4041, 7);
        context.SaveChanges();
    }

    private static void AddSampleEnrollment(SchoolContext context, Learner? learner, int courseId, double grade)
    {
        if (learner != null && !context.Enrollments.Any(e => e.LearnerID == learner.LearnerID && e.CourseID == courseId))
            context.Enrollments.Add(new Enrollment { LearnerID = learner.LearnerID, CourseID = courseId, Grade = grade });
    }
}
