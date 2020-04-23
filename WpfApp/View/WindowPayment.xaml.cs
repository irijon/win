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
        public WindowPayment()
        {
            InitializeComponent();

            PaymentViewModel vmPayment = new PaymentViewModel();
            ServiceViewModel vmService = new ServiceViewModel();
            ClientViewModel vmClient = new ClientViewModel();
            List<Service> services = new List<Service>();
            List<Client> clients = new List<Client>();
            foreach (Service r in vmService.ServiceList)
            {
                services.Add(r);
            }
            foreach (Client r in vmClient.ClientPerson)
            {
                clients.Add(r);
            }

            ObservableCollection<PaymentDOP> persons = new ObservableCollection<PaymentDOP>();
            FindService finder;
            FindClient finCL;
            foreach (var p in vmPayment.PaymentPerson)
            {
                finder = new FindService(p.Id);
                finCL = new FindClient(p.Id);
                Service rol = services.Find(new Predicate<Service>(finder.ServicePredicate));
                Client cl = clients.Find(new Predicate<Client>(finCL.ClientPredicate));
                persons.Add(new PaymentDOP
                {
                    Id = p.Id,
                    Client = cl.FirstName+" "+cl.LastName,
                    Service = rol.Name,
                    Date = p.Date,
                    Quantity = p.Quantity,
                    Amount = p.Amount,
            });
            }
            Payment.ItemsSource = persons;
        }

        private void Payment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
