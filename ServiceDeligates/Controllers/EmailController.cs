using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ServiceDeligates.Enum;

namespace ServiceDeligates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ReminderServiceResolver reminderService;

        public EmailController(ReminderServiceResolver reminderService)
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
