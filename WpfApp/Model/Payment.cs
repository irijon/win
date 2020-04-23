using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.ViewModel;

namespace WpfApp.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public int ClientId  { get; set; }
        public int ServiceId  { get; set; }
        public Double Amount   { get; set; }
        public int Quantity  { get; set; }
        public DateTime Date  { get; set; }

        public Payment() { }

        public Payment(int id, int ClientId,
                        int ServiceId, DateTime Date, int Quantity, Double Amount)
        {
            this.Id = id;
            this.ClientId  = ClientId;
            this.ServiceId  = ServiceId;
            this.Date  = Date;
            this.Quantity  = Quantity;
            this.Amount   = Amount;
        }

        public Payment ShallowCopy()
        {
            return (Payment)this.MemberwiseClone();
        }

        public Payment CopyFromPaymentDPO(PaymentDOP p)
        {
            ServiceViewModel vmSer = new ServiceViewModel();
            ClientViewModel vmCl = new ClientViewModel();
            int SERId = 0;
            int CLId = 0;
            foreach (var r in vmSer.ServiceList)
            {
                if (r.Name == p.Service)
                {
                    SERId = r.Id;
                    break;
                }
            }
            foreach (var r in vmCl.ClientPerson)
            {
                if (r.FirstName + " " + r.LastName == p.Client)
                {
                    CLId = r.Id;
                    break;
                }
            }
            if (SERId != 0 && CLId != 0)
            {
                this.Id = p.Id;
                this.ServiceId = SERId;
                this.ClientId = CLId;
                this.Date = p.Date;
                this.Quantity = p.Quantity;
                this.Amount = p.Amount;
            }
            return this;
        }
    }
}
