using Microsoft.Extensions.DependencyInjection;

namespace Exercise1_TomskNIPIneft.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel 
            => App.Services.GetRequiredService<MainWindowViewModel>();

    }
}
