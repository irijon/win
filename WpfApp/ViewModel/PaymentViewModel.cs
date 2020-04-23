using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    class PaymentViewModel
    {

        public ObservableCollection<Payment> PaymentPerson { get; set; } =
    new ObservableCollection<Payment>();

        public PaymentViewModel()
        {
            this.PaymentPerson.Add(
                new Payment
                {
                    Id = 1,
                    ClientId = 1,
                    ServiceId = 1,
                    Date = new DateTime(1980, 02, 28),
                    Quantity = 2,
                    Amount = 45,
                });

            this.PaymentPerson.Add(
                new Payment
                {
                    Id = 2,
                    ClientId = 2,
                    ServiceId = 2,
                    Date = new DateTime(1980, 03, 30),
                    Quantity = 5,
                    Amount = 21,
                });

        }
            public int MaxId()
            {
                int max = 0;
                foreach (var r in this.PaymentPerson)
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
