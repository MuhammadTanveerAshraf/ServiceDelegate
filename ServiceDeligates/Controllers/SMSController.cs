using Microsoft.AspNetCore.Mvc;

namespace ServiceDeligates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ReminderServiceDelegate reminderService;

        public SMSController(ReminderServiceDelegate reminderService)
        {
            this.reminderService = reminderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var service = reminderService.Invoke(NotificationTypes.Sms);
            service.SendReminder();
            return Ok();
        }
    }
}
