using Web.Box.WPF.Core;
using Web.Box.WPF.Services;

namespace Web.Box.WPF.MVVM.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly IThemePickerService _themePickerService;

        private INavigationService _navService;
        public INavigationService NavService { get => _navService; set => SetProperty(ref _navService, value); }

        private bool _useLightMode;
        public bool UseLightMode 
        { 
            get => _useLightMode;
            set
            {
                SetProperty(ref _useLightMode, value);
                if (_useLightMode == true)
                {
                    _themePickerService.SetLightTheme();
                }
                else
                {
                    _themePickerService.SetDarkTheme();
                }
            }
        }
        public RelayCommand NavHomeCommand { get; set; }
        public RelayCommand NavSettingsCommand { get; set; }
        public RelayCommand NavGuidCommand { get; set; }

        public MainViewModel(INavigationService navService, IThemePickerService themePickerService)
        {
            NavService = navService;
            _themePickerService = themePickerService;

            NavHomeCommand = new RelayCommand(o => NavService.NavigateTo<HomeViewModel>(), o => true);
            NavSettingsCommand = new RelayCommand(o => NavService.NavigateTo<SettingsViewModel>(), o => true);
            NavGuidCommand = new RelayCommand(o => NavService.NavigateTo<GuidGeneratorViewModel>(), o => true);
        }
    }
}