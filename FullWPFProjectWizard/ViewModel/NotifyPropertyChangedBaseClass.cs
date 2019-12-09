using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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
