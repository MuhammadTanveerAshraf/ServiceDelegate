namespace ServiceDeligates.DI
{
    public class EmailReminderService : IReminderService
    {
        private readonly ILogger<EmailReminderService> logger;
        public EmailReminderService(ILogger<EmailReminderService> logger)
        {
            this.logger = logger;
        }

        public void SendReminder()
        {
            logger.LogWarning("EmailReminderService - Send Reminder - Executed");
        }
    }
}
