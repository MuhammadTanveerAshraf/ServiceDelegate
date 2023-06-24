using ServiceDeligates.DI;

namespace ServiceDeligates
{
    public enum NotificationTypes
    {
        Sms,
        Email,
        Push
    };

    public delegate IReminderService ReminderServiceDelegate(NotificationTypes type);
    public static class DependencyRegistration
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<SmsReminderService>();
            services.AddScoped<PushNotificationReminderService>();
            services.AddScoped<EmailReminderService>();

            services.AddTransient<ReminderServiceDelegate>(serviceProvider => key =>
            {

                return key switch
                {
                    NotificationTypes.Sms => serviceProvider.GetService<SmsReminderService>(),
                    NotificationTypes.Email => serviceProvider.GetService<EmailReminderService>(),
                    NotificationTypes.Push => serviceProvider.GetService<PushNotificationReminderService>(),
                    _ => throw new NotImplementedException()
                };
            });
        }
    }
}
