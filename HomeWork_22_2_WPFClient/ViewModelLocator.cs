using Microsoft.Extensions.DependencyInjection;
using HomeWork_22_2_WPFClient.Services;
using HomeWork_22_2_WPFClient.ViewModel;
using HomeWork_22_2_WPFClient.Pages;
using HomeWork_22_2_WPFClient.Interfaces;
using HomeWork_22_2_WPFClient.Data;

namespace HomeWork_22_2_WPFClient
{
    public class ViewModelLocator
    {
        private static ServiceProvider _provider;

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainViewModel>();
            services.AddTransient<Page1ViewModel>();
            services.AddTransient<PageViewRecordViewModel>();
            services.AddTransient<PageLoginViewModel>();
            services.AddTransient<PageErrorViewModel>();

            services.AddSingleton<PageService>();
            services.AddSingleton<EventBus>();
            services.AddSingleton<MessageBus>();
            services.AddSingleton<IPhoneBook, PhoneBookApi>();
            services.AddSingleton<IAppUser, AppUserApi>();
            services.AddSingleton<IRoleUser, RoleUserApi>();



            _provider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                _provider.GetRequiredService(item.ServiceType);
            }
        }

        public MainViewModel mainViewModel => _provider.GetRequiredService<MainViewModel>();
        //public LogPageViewModel LogPageViewModel => _provider.GetRequiredService<LogPageViewModel>();
        public Page1ViewModel page1 => _provider.GetRequiredService<Page1ViewModel>();
        public PageViewRecordViewModel pageViewRecord => _provider.GetRequiredService<PageViewRecordViewModel>();
        public PageLoginViewModel PageLogin => _provider.GetRequiredService<PageLoginViewModel>();
        public PageErrorViewModel pageError => _provider.GetRequiredService<PageErrorViewModel>();
    }
}
