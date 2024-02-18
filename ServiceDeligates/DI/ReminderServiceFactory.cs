using Microsoft.Extensions.DependencyInjection;
using static ServiceDeligates.Enum;

namespace ServiceDeligates.DI
{
    public class ReminderServiceFactory : IReminderServiceFactory
    {
        private readonly IEnumerable<IReminderService> _reminderServices;
        public ReminderServiceFactory(IEnumerable<IReminderService> reminderServices)
        {
            _reminderServices = reminderServices;
        }

        public IReminderService GetInstance(NotificationTypes type)
        {
            return type switch
            {
                NotificationTypes.Email => GetService(typeof(EmailReminderService)),
                NotificationTypes.Push => GetService(typeof(PushNotificationReminderService)),
                NotificationTypes.SMS => GetService(typeof(SmsReminderService)),
                _ => throw new InvalidOperationException()
            };
        }

        public IReminderService GetService(Type type)
        {
            return _reminderServices.FirstOrDefault(x => x.GetType() == type) ?? throw new InvalidOperationException();
        }
    }
}
