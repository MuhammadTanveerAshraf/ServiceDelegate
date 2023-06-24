namespace ServiceDeligates.DI
{
    public class PushNotificationReminderService : IReminderService
    {
        private readonly ILogger<PushNotificationReminderService> logger;
        public PushNotificationReminderService(ILogger<PushNotificationReminderService> logger)
        {
            this.logger = logger;
        }
        public void SendReminder()
        {
            logger.LogWarning("PushNotificationReminderService - Send Reminder - Executed");
        }
    }
}
