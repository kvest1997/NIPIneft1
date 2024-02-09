using Exercise1_TomskNIPIneft.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise1_TomskNIPIneft.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModel(this IServiceCollection services)
            => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<ComputerSpecificationModel>()
            ;
    }
}
