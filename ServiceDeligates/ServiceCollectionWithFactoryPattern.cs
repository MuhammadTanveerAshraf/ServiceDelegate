using ServiceDeligates.DI;

namespace ServiceDeligates
{
    public static class ServiceCollectionWithFactoryPattern
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IReminderService, EmailReminderService>();
            services.AddScoped<IReminderService, PushNotificationReminderService>();
            services.AddScoped<IReminderService, SmsReminderService>();
            services.AddTransient<IReminderServiceFactory, ReminderServiceFactory>();
        }
    }
}
