namespace ServiceDeligates.DI
{
    public class SmsReminderService : IReminderService
    {
        private readonly ILogger<SmsReminderService> logger;
        public SmsReminderService(ILogger<SmsReminderService> logger)
        {
            this.logger = logger;
        }

        public void SendReminder()
        {
            logger.LogWarning("SmsReminderService - Send Reminder - Executed");
        }
    }
}
