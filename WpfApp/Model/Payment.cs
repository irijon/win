using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
