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
    }
}