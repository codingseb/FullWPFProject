using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FullWPFProjectWizard
{
    public class ConfigViewModel : NotifyPropertyChangedBaseClass
    {
        public List<LocalizationFileFormat> LanguageFilesFormats { get; set; } = new List<LocalizationFileFormat>()
        {
            new LocalizationFileFormat() {Text = "Json", Value = "Json", Selected = true },
            new LocalizationFileFormat() {Text = "Yaml", Value = "Yaml"},
        };
    }
}
