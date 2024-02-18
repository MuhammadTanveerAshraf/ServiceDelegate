using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceDeligates.DI;
using static ServiceDeligates.Enum;

namespace ServiceDeligates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IReminderServiceFactory _reminderServiceFactory;

        public EmailController(IReminderServiceFactory reminderServiceFactory)
        {
            _reminderServiceFactory = reminderServiceFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var service = _reminderServiceFactory.GetInstance(NotificationTypes.Email);
            service.SendReminder();
            return Ok();
        }
    }
}
