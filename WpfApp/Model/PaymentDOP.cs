using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    class PaymentDOP
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Service { get; set; }
        public Double Amount { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public PaymentDOP() { }

        public PaymentDOP(int id, string Client,
                        string Service, DateTime Date, int Quantity, Double Amount)
        {
            this.Id = id;
            this.Client = Client;
            this.Service = Service;
            this.Date = Date;
            this.Quantity = Quantity;
            this.Amount = Amount;
        }
    }
}
