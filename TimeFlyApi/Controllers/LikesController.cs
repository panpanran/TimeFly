using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeFlyApi.Data;
using TimeFlyApi.Helpers;

namespace TimeFlyApi.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly IBaseRepository _repo;
        private readonly IMapper _mapper;

        public LikesController(IBaseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "IsUserLikees")]
        public async Task<IActionResult> IsUserLikees(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var usersFromRepo = await _repo.GetUserLikes(userId, false);
            bool isLikee = usersFromRepo.Any(x => x == id);
            return Ok(isLikee);
        }
    }
}