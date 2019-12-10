using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FullWPFProjectWizard
{
    public class ConfigurationWizard : IWizard
    {
        private readonly ConfigViewModel viewModel = new ConfigViewModel();

        // This method is called before opening any item that
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        // This method is only called for item templates,
        // not for project templates.
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem)
        {
        }

        // This method is called after the project is created.
        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
            WizardWindow window = new WizardWindow()
            {
                DataContext = viewModel
            };

            window.ShowDialog();

            IEnumerable<LocalizationFileFormat> selectedLocalizationFileFormats = viewModel.LanguageFilesFormats
                    .Where(lff => lff.Selected);

            replacementsDictionary["$LocalizationFileLoaders$"] = string.Join("\r\n",
                selectedLocalizationFileFormats
                    .Select(localizationFileFormat => Resources.FileLoaderNugetReference.Replace("$Format$", localizationFileFormat.Value)));

            replacementsDictionary["$FileLoaderAddInCode$"] = string.Join("\r\n",
                selectedLocalizationFileFormats
                    .Select(localizationFileFormat => Resources.FileLoaderAddInCode.Replace("$Format$", localizationFileFormat.Value)));
        }

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
