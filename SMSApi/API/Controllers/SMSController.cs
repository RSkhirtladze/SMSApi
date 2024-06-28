using Microsoft.AspNetCore.Mvc;
using SMSApi.API.DTOs;
using SMSApi.Application.Interfaces;
using Twilio.Http;

namespace SMSApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _smsService;
        private readonly ILogger<SMSController> _logger;

        public SMSController(ISMSService smsService, ILogger<SMSController> logger)
        {
            _smsService = smsService;
            _logger = logger;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(SMSMessageDTO smsMessageDTO)
        {
            try
            {
                var result = await _smsService.SendSMSAsync(smsMessageDTO.Phone, smsMessageDTO.Text);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch()
            {

            }
        }
    }
}
