using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.DTOs;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Core;
using OpenIddict.Validation.AspNetCore;

namespace OpeniddictServer.Controllers
{
    [Route("api/user/board")]
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IOpenIddictApplicationManager _openIddictApplicationManager;
        private readonly IUserService _userService;

        public UserController(
            IOpenIddictApplicationManager openIddictApplicationManager,
            IUserService userService
            )
        {
            _openIddictApplicationManager = openIddictApplicationManager;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<BoardDto>> CreateUserBoard(BoardDto board)
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == "sub").Value;
            try
            {
                if (await _openIddictApplicationManager.FindByClientIdAsync(board.Name) == null)
                {
                    await _openIddictApplicationManager.CreateAsync(new OpenIddictApplicationDescriptor
                    {
                        ClientId = board.Name,
                        ClientSecret = board.Secret,
                        DisplayName = board.Name,
                        Permissions =
                        {
                            OpenIddictConstants.Permissions.Endpoints.Authorization,
                            OpenIddictConstants.Permissions.Endpoints.Token,
                            OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,
                            OpenIddictConstants.Permissions.Prefixes.Scope + "dataAIIR"
                        }
                    });
                    await _userService.RegisterBoard(new Guid(userId), board.Name, board.Secret);
                }


                return Ok(board);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> CreateUserBoard(string boardName)
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == "sub").Value;

            try
            {
                await _userService.RemoveBoard(new Guid(userId), boardName);
                var app = await _openIddictApplicationManager.FindByClientIdAsync(boardName);
                await _openIddictApplicationManager.DeleteAsync(app);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
