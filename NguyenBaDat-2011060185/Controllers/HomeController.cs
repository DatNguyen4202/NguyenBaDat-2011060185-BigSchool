using NguyenBaDat_2011060185.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using NguyenBaDat_2011060185.XemModels;

namespace NguyenBaDat_2011060185.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        private bool ShowAction;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now);

            var XemModel = new CourseXemModels();
            {
                upcomingCourses = GetUpcomingCourses();
                ShowAction = User.Identity.IsAuthenticated;
            }

            return View(XemModel);

            IQueryable<Course> GetUpcomingCourses()
            {
                return upcomingCourses;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}