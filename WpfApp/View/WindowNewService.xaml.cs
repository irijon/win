using System.Windows;

namespace WpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для WindowNewClient.xaml
    /// </summary>
    public partial class WindowNewService : Window
    {
        public WindowNewService()
        {
            InitializeComponent();
        }
        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
