using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    class ClientViewModel
    {

        public ObservableCollection<Client> ClientPerson { get; set; } =
    new ObservableCollection<Client>();

        public ClientViewModel()
        {
            this.ClientPerson.Add(
                new Client
                {
                    Id =1,
            FirstName = "Andrei",
            LastName = "Fedorov",
            Status = "M",
            Phone = "89065467890",
            Email = "gmail",
        });

            this.ClientPerson.Add(
                new Client
                {
                    Id = 2,
                    FirstName = "Fedor",
                    LastName = "Andreev",
                    Status = "j",
                    Phone = "",
                    Email = "",
                });
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ClientPerson)
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
