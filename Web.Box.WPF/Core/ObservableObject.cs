using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Web.Box.WPF.Core
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            try
            {
                //Compare the current and new values, and raise the event in case they're different.
                if (!EqualityComparer<T>.Default.Equals(field, newValue))
                {
                    field = newValue;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Form Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return false;
        }
    }
}