using Microsoft.AspNetCore.Mvc;
using ServiceDeligates.DI;
using static ServiceDeligates.Enum;

namespace ServiceDeligates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly IReminderServiceFactory _reminderServiceFactory;

        public SMSController(IReminderServiceFactory reminderServiceFactory)
        {
            _reminderServiceFactory = reminderServiceFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var service = _reminderServiceFactory.GetInstance(NotificationTypes.SMS);
            service.SendReminder();
            return Ok();
        }
    }
}
