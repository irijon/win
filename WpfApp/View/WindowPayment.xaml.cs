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
        static ServiceViewModel vmService = new ServiceViewModel();
        static ClientViewModel vmClient = new ClientViewModel();
        List<Service> services = vmService.ServiceList.ToList();
        List<Client> clients = vmClient.ClientPerson.ToList();
        ObservableCollection<PaymentDOP> persons = new ObservableCollection<PaymentDOP>();

        public WindowPayment()
        {
            InitializeComponent();

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
            WindowNewPayment wnEmployee = new WindowNewPayment
            {
                Title = "Новая покупка",
                Owner = this
            };

            // формирование кода нового собрудника
            int maxIdPerson = vmPayment.MaxId() + 1;
            PaymentDOP per = new PaymentDOP
            {
                Id = maxIdPerson,
                Date = DateTime.Now
            };

            wnEmployee.DataContext = per;
            wnEmployee.CbSer.ItemsSource = services;
            wnEmployee.CbCl.ItemsSource = clients;

            if (wnEmployee.ShowDialog() == true)
            {
                Service r = (Service)wnEmployee.CbSer.SelectedValue;
                Client c = (Client)wnEmployee.CbCl.SelectedValue;
                per.Service = r.Name;
                per.Client = c.FirstName + " " + c.LastName;
                persons.Add(per);

                Payment p = new Payment();
                p = p.CopyFromPaymentDPO(per);
                vmPayment.PaymentPerson.Add(p);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PaymentDOP person = (PaymentDOP)Payment.SelectedItem;
            if (person != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные ?",
                    "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    // удаление данных в списке отображения данных
                    persons.Remove(person);

                    // удаление данных в списке классов ListPerson<Person>
                    Payment per = new Payment();
                    per = per.CopyFromPaymentDPO(person);
                    vmPayment.PaymentPerson.Remove(per);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные по сотруднику для удаления",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPayment wnEmployee = new WindowNewPayment
            {
                Title = "Редактирование данных",
                Owner = this
            };
            PaymentDOP perDPO = (PaymentDOP)Payment.SelectedValue;
            PaymentDOP tempPerDPO;  // временный класс для редактирования
            if (perDPO != null)
            {
                tempPerDPO = perDPO.ShallowCopy();
                wnEmployee.DataContext = tempPerDPO;
                wnEmployee.CbSer.ItemsSource = services;
                wnEmployee.CbCl.ItemsSource = clients;
                wnEmployee.CbCl.Text = tempPerDPO.Client.Split(new char[] { ' ' })[0];
                wnEmployee.CbSer.Text = tempPerDPO.Service;

                if (wnEmployee.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных  
                    Service r = (Service)wnEmployee.CbSer.SelectedValue;
                    Client p = (Client)wnEmployee.CbCl.SelectedValue;
                    perDPO.Client = p.FirstName + " " + p.LastName;
                    perDPO.Service = r.Name;
                    perDPO.Quantity = tempPerDPO.Quantity;
                    perDPO.Date = tempPerDPO.Date;
                    perDPO.Amount = tempPerDPO.Amount;

                    Payment.ItemsSource = null;
                    Payment.ItemsSource = persons;

                    // перенос данных из класса отображения данных в класс Person
                    FindPayment finder = new FindPayment(perDPO.Id);
                    List<Payment> listPerson = vmPayment.PaymentPerson.ToList();
                    Payment z = listPerson.Find(new Predicate<Payment>(finder.PaymentPredicate));
                    z = z.CopyFromPaymentDPO(perDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать покупку для редактированния",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
