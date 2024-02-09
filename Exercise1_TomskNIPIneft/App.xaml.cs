using Exercise1_TomskNIPIneft.Services;
using Exercise1_TomskNIPIneft.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Application = System.Windows.Application;

namespace Exercise1_TomskNIPIneft
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost __Host;
        public static IHost Host => __Host
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider Services => Host.Services;

        internal static void ConfigureServices(HostBuilderContext host,
            IServiceCollection services)
            => services
            .AddServices()
            .AddViewModel()
            ;
            
        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            base.OnStartup(e);

            await host.StopAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            host.Services.GetService<MainWindowViewModel>().OnCloseCommand();

            base.OnExit(e);
            await host.StopAsync();

        }

    }

}
