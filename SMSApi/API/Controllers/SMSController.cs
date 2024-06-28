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

        public SMSController(ISMSService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(SMSMessageDTO smsMessageDTO)
        {
            await _smsService.SendSMSAsync(smsMessageDTO.Phone, smsMessageDTO.Text);

            return Ok();
        }
    }
}
