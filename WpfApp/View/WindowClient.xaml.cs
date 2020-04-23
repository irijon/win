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
using System.Windows.Shapes;
using WpfApp.Model;
using WpfApp.ViewModel;

namespace WpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для WindowClient.xaml
    /// </summary>
    public partial class WindowClient : Window
    {
        ClientViewModel vmClient = new ClientViewModel();
        public WindowClient()
        {
            InitializeComponent();
            Clients.ItemsSource = vmClient.ClientPerson;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewClient wnClient = new WindowNewClient { Title = "Новый клиент", Owner = this };
            // формирование кода новой должности
            int maxId = vmClient.MaxId() + 1;
            Client role = new Client
            {
                Id = maxId
            };
            wnClient.DataContext = role;
            if (wnClient.ShowDialog() == true)
            {
                vmClient.ClientPerson.Add(role);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Client role = (Client)Clients.SelectedItem;
            if (role != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные?", "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmClient.ClientPerson.Remove(role);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать запись для удаления",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewClient wnClient = new WindowNewClient
            {
                Title = "Редактирование должности",
                Owner = this
            };
            Client role = Clients.SelectedItem as Client;
            if (role != null)
            {
                Client tempRole = role.ShallowCopy();
                wnClient.DataContext = tempRole;
                if (wnClient.ShowDialog() == true)
                {
                    role.FirstName = tempRole.FirstName;
                    role.LastName = tempRole.LastName;
                    role.Status = tempRole.Status;
                    role.Phone = tempRole.Phone;
                    role.Email = tempRole.Email;
                    Clients.ItemsSource = null;
                    Clients.ItemsSource = vmClient.ClientPerson;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать запись для редактированния",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
