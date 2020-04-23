using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    class ServiceViewModel
    {
        public ObservableCollection<Service> ServiceList { get; set; } =
    new ObservableCollection<Service>();

        public ServiceViewModel()
        {
            this.ServiceList.Add(
                new Service
                {
                    Id = 1,
                    Price = 23,
                    Name = "Услуга1",
                });

            this.ServiceList.Add(
                new Service
                {
                    Id = 2,
                    Price = 65,
                    Name = "Услуга2",
                });
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ServiceList)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }

    }
}
