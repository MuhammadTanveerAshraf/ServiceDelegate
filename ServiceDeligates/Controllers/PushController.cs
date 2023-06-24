using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceDeligates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushController : ControllerBase
    {
        private readonly ReminderServiceDelegate reminderService;

        public PushController(ReminderServiceDelegate reminderService)
        {
            this.reminderService = reminderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var service = reminderService.Invoke(NotificationTypes.Push);
            service.SendReminder();
            return Ok();
        }
    }
}
