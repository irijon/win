using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using WpfApp.Helper;
using WpfApp.Model;
using WpfApp.ViewModel;

namespace WpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для WindowPayment.xaml
    /// </summary>
    public partial class WindowPayment : Window
    {
        PaymentViewModel vmPayment = new PaymentViewModel();
        ServiceViewModel vmService;
        ClientViewModel vmClient;
        List<Service> services;
        List<Client> clients;
        public WindowPayment()
        {
            InitializeComponent();

            vmPayment = new PaymentViewModel();
            vmService = new ServiceViewModel();
            vmClient = new ClientViewModel();
            services = vmService.ServiceList.ToList();
            clients = vmClient.ClientPerson.ToList();

            ObservableCollection<PaymentDOP> persons = new ObservableCollection<PaymentDOP>();
            foreach (var pay in vmPayment.PaymentPerson)
            {
                PaymentDOP p = new PaymentDOP();
                p = p.CopyFromPerson(pay);
                persons.Add(p);
            }
            Payment.ItemsSource = persons;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
