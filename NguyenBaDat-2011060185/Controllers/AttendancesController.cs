using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using NguyenBaDat_2011060185.DTOs;
using NguyenBaDat_2011060185.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NguyenBaDat_2011060185.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public int CourseId { get; private set; }
        public string AttendeeId { get; private set; }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already exists !");

            var attendance = new Attendance();
            {
                CourseId = attendanceDto.CourseId;
                AttendeeId = userId;
            };

            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();
        }

    }
}




