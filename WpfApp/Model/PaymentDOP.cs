using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.ViewModel;

namespace WpfApp.Model
{
    public class PaymentDOP
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
        public PaymentDOP ShallowCopy()
        {
            return (PaymentDOP)this.MemberwiseClone();
        }
        public PaymentDOP CopyFromPerson(Payment person)
        {
            PaymentDOP perDPO = new PaymentDOP();
            ServiceViewModel vmSer = new ServiceViewModel();
            ClientViewModel vmCl = new ClientViewModel();
            string ser = string.Empty;
            string cl = string.Empty;
            foreach (var r in vmSer.ServiceList)
            {
                if (r.Id == person.ServiceId)
                {
                    ser = r.Name;
                    break;
                }
            }
            foreach (var r in vmCl.ClientPerson)
            {
                if (r.Id == person.ClientId)
                {
                    cl = r.FirstName + " " + r.LastName;
                    break;
                }
            }
            if (ser != string.Empty&& cl != string.Empty)
            {
                perDPO.Id = person.Id;
                perDPO.Quantity = person.Quantity;
                perDPO.Service = ser;
                perDPO.Client = cl;
                perDPO.Amount = person.Amount;
                perDPO.Date = person.Date;
            }
            return perDPO;
        }
    }
}
