using Microsoft.AspNetCore.Mvc;
using SMSApi.DTOs;

namespace SMSApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SMSController : ControllerBase
    {
        private readonly ILogger<SMSController> _logger;

        public SMSController(ILogger<SMSController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(SMSMessageDTO smsMessageDTO)
        {

        }
    }
}
