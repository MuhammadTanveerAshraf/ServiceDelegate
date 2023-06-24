using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceDeligates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ReminderServiceDelegate reminderService;

        public EmailController(ReminderServiceDelegate reminderService)
        {
            this.reminderService = reminderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var service = reminderService.Invoke(NotificationTypes.Email);
            service.SendReminder();
            return Ok();
        }
    }
}
