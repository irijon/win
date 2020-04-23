using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.Helper
{
    class FindService
    {
        int id;
        public FindService(int id)
        {
            this.id = id;
        }
        public bool ServicePredicate(Service pay)
        {
            return pay.Id == id;
        }
    }
}
