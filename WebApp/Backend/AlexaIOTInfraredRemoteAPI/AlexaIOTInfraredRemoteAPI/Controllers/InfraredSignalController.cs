using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.DTOs;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AlexaIOTInfraredRemoteAPI.Controllers
{
    [Route("api/infrared/signals")]
    [ApiController]
    [Authorize]
    public class InfraredSignalController : ControllerBase
    {
        private readonly IInfraredSignalService _infraredSignalService;
        public InfraredSignalController(IInfraredSignalService infraredSignalService)
        {
            _infraredSignalService = infraredSignalService;
        }
        [HttpGet]
        public async Task<ActionResult<List<InfraredSignal>>> GetInfraredSignals(string sort)
        {
            var infraredSignals = await _infraredSignalService.GetInfraredSignals(sort);
            return Ok(infraredSignals);
        }
        [HttpPost]
        public async Task<ActionResult> CreateInfraredSignal([FromBody] InsertInfraredSignalRequest request)
        {
            var identityUserId = User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            var infraredSignal = await _infraredSignalService.CreateInfraredSignal(Guid.Parse(identityUserId), request.Length, request.InfraredData);
            return Ok(infraredSignal);
        }
    }
}
