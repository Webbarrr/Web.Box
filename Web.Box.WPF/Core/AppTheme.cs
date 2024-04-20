using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Web.Box.WPF.Core
{
    public class AppTheme
    {
        public static void ChangeTheme(Uri themeUri)
        {
            var theme = new ResourceDictionary { Source = themeUri };

            App.Current.Resources.MergedDictionaries[0].Clear();
            App.Current.Resources.MergedDictionaries.Add(theme);
        }
    }
}
