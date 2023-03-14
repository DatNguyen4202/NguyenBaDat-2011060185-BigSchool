using Microsoft.AspNet.Identity;
using NguyenBaDat_2011060185.Models;
using NguyenBaDat_2011060185.XemModels;
using System;
using System.Collections.Generic;
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
            var viewModel = new CourseXemModels
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
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
    }
}