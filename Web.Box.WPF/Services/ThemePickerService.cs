using Web.Box.WPF.Core;

namespace Web.Box.WPF.Services
{
    public interface IThemePickerService
    {
        void SetDarkTheme();

        void SetLightTheme();
    }

    public class ThemePickerService : IThemePickerService
    {
        private const string MAIN_PATH = "../Themes";
        private const string DARK_PATH = "/DarkTheme.xaml";
        private const string LIGHT_PATH = "/LightTheme.xaml";

        public void SetDarkTheme()
        {
            AppTheme.ChangeTheme(new Uri($"{MAIN_PATH}{DARK_PATH}", UriKind.Relative));
        }

        public void SetLightTheme()
        {
            AppTheme.ChangeTheme(new Uri($"{MAIN_PATH}{LIGHT_PATH}", UriKind.Relative));
        }
    }
}