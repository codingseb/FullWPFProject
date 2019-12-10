using System.Collections.Generic;

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
