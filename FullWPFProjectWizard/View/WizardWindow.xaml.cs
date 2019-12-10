using System.Windows;

namespace FullWPFProjectWizard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WizardWindow : Window
    {
        public WizardWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
