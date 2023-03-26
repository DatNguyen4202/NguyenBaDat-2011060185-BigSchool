using Microsoft.AspNet.Identity;
using NguyenBaDat_2011060185.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NguyenBaDat_2011060185.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbcontext;
        private string FollowerId;
        private string FolloweeId;

        public FollowingsController() 
        {
            _dbcontext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(Following followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbcontext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");

            var following = new Following();
            {
                FollowerId = userId;
                FolloweeId = followingDto.FolloweeId;
            };

            _dbcontext.Followings.Add(following);
            _dbcontext.SaveChanges();

            return Ok();
        }
    }
}
