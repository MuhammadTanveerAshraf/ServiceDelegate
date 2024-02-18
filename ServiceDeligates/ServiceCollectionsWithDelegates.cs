using ServiceDeligates.DI;
using static ServiceDeligates.Enum;

namespace ServiceDeligates
{
    public delegate IReminderService ReminderServiceResolver(NotificationTypes identifier);
    public static class ServiceCollectionsWithDelegates
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<SmsReminderService>();
            services.AddTransient<EmailReminderService>();
            services.AddTransient<PushNotificationReminderService>();

            services.AddTransient<ReminderServiceResolver>(serviceProvider => token =>
            {
                switch (token)
                {
                    case NotificationTypes.Email:
                        return serviceProvider.GetService<EmailReminderService>();
                    case NotificationTypes.Push:
                        return serviceProvider.GetService<PushNotificationReminderService>();
                    case NotificationTypes.SMS:
                        return serviceProvider.GetService<SmsReminderService>();
                    default:
                        throw new InvalidOperationException();
                }

                //return token switch
                //{
                //    "Email" => serviceProvider.GetService<EmailReminderService>(),
                //    "Push" => serviceProvider.GetService<PushNotificationReminderService>(),
                //    "SMS" => serviceProvider.GetService<SmsReminderService>(),
                //    _ => throw new InvalidOperationException()
                //};
            });
        }
    }
}
