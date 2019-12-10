using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FullWPFProjectWizard
{
    public class NotifyPropertyChangedBaseClass : INotifyPropertyChanged
    {
        /// <summary>
        /// Notify that the value of a property has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Generate the PropertyChanged event
        /// To manually notify that a property has changed
        /// </summary>
        /// <param name="propertyName">The name of property that changed (Think to use nameof for better refactoring) (By default the calling property)</param>
        public virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
