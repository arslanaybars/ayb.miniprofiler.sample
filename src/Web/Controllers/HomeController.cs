using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Profiling;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
           // not have good example idea :)
            using (MiniProfiler.Current.Step("Send email to admin who got this request"))
            {
                using (MiniProfiler.Current.Step("Complex business logic - 1"))
                {
                    // email codes
                    Thread.Sleep(400);
                }
                using (MiniProfiler.Current.Step("Complex business logic - 2"))
                {
                    // email codes
                    Thread.Sleep(200);
                }

                // email codes
                Thread.Sleep(1000);
            }

            FakeHttpCall.Call("One more call here");


            var result = await _context.Students
                .Include(x => x.StudentCourses)
                    .ThenInclude(x => x.Course)
                .Include(x => x.Address)
                .AsNoTracking()
                .Where(x => x.StudentCourses.Any(y => y.CourseId > 50) && 
                            x.Name.StartsWith("a") &&
                            x.Address.City.EndsWith("a"))
                .OrderByDescending(x => x.Name)
                .ToListAsync();

            return View(result);
        }

        public IActionResult HttpCall([FromQuery]string text)
        {
            FakeHttpCall.Call(text);
            return Ok(text);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
