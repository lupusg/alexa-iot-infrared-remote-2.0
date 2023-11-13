using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlexaIOTInfraredRemoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
