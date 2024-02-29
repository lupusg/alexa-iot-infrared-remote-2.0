using AlexaIOTInfraredRemoteAPI.Domain.DTOs;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OpenIddict.Abstractions;

namespace AlexaIOTInfraredRemoteAPI.Controllers.User
{
    [Route("api/user/board")]
    [ApiController]
    [Authorize]
    public class UserBoardsController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserBoardsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<BoardDto>> GetBoards()
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == "sub").Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            try
            {
                var boards = await _userService.GetUserBoards(new Guid(userId));
                return Ok(boards);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred");
            }
        }
    }
}
