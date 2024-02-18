using static ServiceDeligates.Enum;

namespace ServiceDeligates.DI
{
    public interface IReminderServiceFactory
    {
        IReminderService GetInstance(NotificationTypes type);
    }
}
