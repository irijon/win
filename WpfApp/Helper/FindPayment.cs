using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.Helper
{
    public class FindPayment
    {
        int id;
        public FindPayment(int id)
        {
            this.id = id;
        }
        public bool PaymentPredicate(Payment pay)
        {
            return pay.Id == id;
        }
    }
}

