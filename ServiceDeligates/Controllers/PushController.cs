using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ServiceDeligates.Enum;

namespace ServiceDeligates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushController : ControllerBase
    {
        private readonly ReminderServiceResolver reminderService;

        public PushController(ReminderServiceResolver reminderService)
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
