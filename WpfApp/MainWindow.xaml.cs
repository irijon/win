using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.View;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int IdService { get; set; }
        public static int IdClient { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Client_OnClick(object sender, RoutedEventArgs e)
        {
            WindowClient wEmployee = new WindowClient();
            wEmployee.Show();
        }

        private void Service_OnClick(object sender, RoutedEventArgs e)
        {
            WindowService wRole = new WindowService();
            wRole.Show();
        }

        private void Payment_OnClick(object sender, RoutedEventArgs e)
        {
            WindowPayment wRole = new WindowPayment();
            wRole.Show();
        }
    }
}
