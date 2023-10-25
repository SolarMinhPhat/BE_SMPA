using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarMP.Interfaces;
using SolarMP.Models;
using Twilio.Types;

namespace SolarMP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwilioController : ControllerBase
    {
        private readonly ITwilio service;
        private readonly solarMPContext context;
        public TwilioController(ITwilio service, solarMPContext context)
        {
            this.service = service;
            this.context = context;
        }
        public class PhoneOtpRequest
        {
            public string PhoneNumber { get; set; }
        }

        [HttpPost("sendOtp")]
        public async Task<IActionResult> SendOTP([FromBody] PhoneOtpRequest request)
        {
            string digitsOnly = new string(request.PhoneNumber.Where(char.IsDigit).ToArray());

            if (!digitsOnly.StartsWith("+84"))
            {
                digitsOnly = "+84" + digitsOnly;
            }
            var timeSendOtp = await service.SendOTP(digitsOnly);
            return Ok(new { TimeSendOTP = timeSendOtp });
        }

        [HttpPost("verifyOtp")]
        public async Task<IActionResult> VerifyOtp(string phoneNumber, string otp)
        {
            string digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());

            if (!digitsOnly.StartsWith("+84"))
            {
                digitsOnly = "+84" + digitsOnly;
            }
            var status = await service.VerifyOTP(digitsOnly, otp);
            if (status == "approved")
            {
                var check = await this.context.Account.Where(x=>x.Phone.Equals(phoneNumber)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Status = true;
                    this.context.Account.Update(check);
                    await this.context.SaveChangesAsync();
                    return Ok("true");
                }
                else
                {
                    return BadRequest("Không tìm thấy tài khoản đã đăng ký");
                }
                
            }

            return Ok(new { Status = status });
        }
    }
}
