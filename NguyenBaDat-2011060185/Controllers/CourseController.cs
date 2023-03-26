using Microsoft.AspNet.Identity;
using NguyenBaDat_2011060185.Models;
using NguyenBaDat_2011060185.XemModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenBaDat_2011060185.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Course
        [Authorize]
        public ActionResult Create()
        {
            var XemModels = new CourseXemModels
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(XemModels);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseXemModels xemModels)
        {
            if (!ModelState.IsValid)
            {
                xemModels.Categories = _dbContext.Categories.ToList();
                return View("Create", xemModels);
            }

            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = xemModels.GetDateTime(),
                CategoryId = xemModels.Category,
                Place = xemModels.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Attending() 
        {
            var userId = User.Identity.GetUserId();

            var courses = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Course)
                .Include(1 => 1.Lecturer)
                .Include(1 => 1.Category)
                .ToList();

            var XemModel = new CourseXemModels
            {
                UpcomingCourse = courses,
                ShowAction = User.Identity.IsAuthenticated
            };

            return View(XemModel);
        }
    }
}