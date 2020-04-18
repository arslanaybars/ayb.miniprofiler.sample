using System;
using System.Threading.Tasks;
using System.Linq;
using StackExchange.Profiling;
using StackExchange.Profiling.Storage;

namespace Data
{
    public class DbInitializer
    {
        public static async Task SeedAsync(AppDbContext context)
        {

            if (!context.Courses.Any())
            {
                await InsertCourses(context);
            }

            if (!context.Students.Any())
            {
                await InsertStudents(context);
            }

            if (!context.StudentCourses.Any())
            {
                await InsertStudentCourses(context);
            }

        }

        private static async Task InsertStudentCourses(AppDbContext context)
        {
            var students = context.Students;

            foreach (var student in students)
            {
                context.StudentCourses.Add(new StudentCourse
                {
                    StudentId = student.Id,
                    CourseId = new Random().Next(1, 100)
                });
            };

            await context.SaveChangesAsync();
        }

        private static async Task InsertStudents(AppDbContext context)
        {
            for (int i = 0; i < 1000; i++)
            {
                context.Students.Add(new Student());
            }

            await context.SaveChangesAsync();
        }

        private static async Task InsertCourses(AppDbContext context)
        {
            for (int i = 0; i < 100; i++)
            {
                context.Courses.Add(new Course());
            }

            await context.SaveChangesAsync();
        }
    }
}
