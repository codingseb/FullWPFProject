using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FullWPFProjectWizard
{
    public class ConfigurationWizard : IWizard
    {
        private readonly ConfigViewModel viewModel = new ConfigViewModel();
        private string sourceDirectory;
        private Dictionary<string, string> replacementsDictionary;
        private IEnumerable<LocalizationFileFormat> selectedLocalizationFileFormats;

        // This method is called before opening any item that
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
            string destinationDir = Path.GetDirectoryName(project.FileName);

            selectedLocalizationFileFormats.ToList()
                .ForEach(localizationFileFormat =>
                {
                    string sourceFileName = Path.Combine(sourceDirectory, "lang", Resources.LocFileName.Replace("$format$", localizationFileFormat.Value.ToLower()));

                    if(File.Exists(sourceFileName))
                    {
                        string destinationFileName = Path.Combine(destinationDir,
                            "lang",
                            Resources.LocFileName
                                .Replace("$format$", localizationFileFormat.Value.ToLower())
                                .Replace("$projectname$", project.Name));

                        if(localizationFileFormat.ReplaceContent)
                        {
                            string fileContent = File.ReadAllText(sourceFileName);

                            replacementsDictionary.Keys.ToList()
                                .ForEach(key => fileContent = fileContent.Replace(key, replacementsDictionary[key]));

                            File.WriteAllText(destinationFileName, fileContent);
                        }
                        else
                        {
                            File.Copy(sourceFileName, destinationFileName, true);
                        }
                    }
                });
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
            this.replacementsDictionary = replacementsDictionary;

            WizardWindow window = new WizardWindow()
            {
                DataContext = viewModel
            };

            window.ShowDialog();

            selectedLocalizationFileFormats = viewModel.LanguageFilesFormats
                    .Where(lff => lff.Selected);

            replacementsDictionary["$LocalizationFileLoaders$"] = string.Join("\r\n",
                selectedLocalizationFileFormats
                    .Select(localizationFileFormat => Resources.FileLoaderNugetReference.Replace("$Format$", localizationFileFormat.Value)));

            replacementsDictionary["$FileLoaderAddInCode$"] = string.Join("\r\n",
                selectedLocalizationFileFormats
                    .Select(localizationFileFormat => Resources.FileLoaderAddInCode.Replace("$Format$", localizationFileFormat.Value)));

            sourceDirectory = Path.GetDirectoryName(customParams[0].ToString());
        }

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
