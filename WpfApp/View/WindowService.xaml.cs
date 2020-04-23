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
    /// Логика взаимодействия для WindowService.xaml
    /// </summary>
    public partial class WindowService : Window
    {
        ServiceViewModel vmService = new ServiceViewModel();
        public WindowService()
        {
            InitializeComponent();
            Services.ItemsSource = vmService.ServiceList;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewService wnClient = new WindowNewService { Title = "Новая услуга", Owner = this };
            // формирование кода новой должности
            int maxId = vmService.MaxId() + 1;
            Service role = new Service
            {
                Id = maxId
            };
            wnClient.DataContext = role;
            if (wnClient.ShowDialog() == true)
            {
                vmService.ServiceList.Add(role);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Service role = (Service)Services.SelectedItem;
            if (role != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные?", "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmService.ServiceList.Remove(role);
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
            WindowNewService wnClient = new WindowNewService
            {
                Title = "Редактирование услуги",
                Owner = this
            };
            Service role = Services.SelectedItem as Service;
            if (role != null)
            {
                Service tempRole = role.ShallowCopy();
                wnClient.DataContext = tempRole;
                if (wnClient.ShowDialog() == true)
                {
                    role.Price = tempRole.Price;
                    role.Name = tempRole.Name;
                    Services.ItemsSource = null;
                    Services.ItemsSource = vmService.ServiceList;
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
