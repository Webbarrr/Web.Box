using Web.Box.WPF.Core;
using Web.Box.WPF.Services;

namespace Web.Box.WPF.MVVM.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private INavigationService _navService;
        public INavigationService NavService { get => _navService; set => SetProperty(ref _navService, value); }

        public RelayCommand NavHomeCommand { get; set; }
        public RelayCommand NavSettingsCommand { get; set; }
        public RelayCommand NavGuidCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            NavService = navService;

            NavHomeCommand = new RelayCommand(o => NavService.NavigateTo<HomeViewModel>(), o => true);
            NavSettingsCommand = new RelayCommand(o => NavService.NavigateTo<SettingsViewModel>(), o => true);
            NavGuidCommand = new RelayCommand(o => NavService.NavigateTo<GuidGeneratorViewModel>(), o => true);
        }
    }
}