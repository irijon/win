using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.Helper
{
    class FindClient
    {
        int id;
        public FindClient(int id)
        {
            this.id = id;
        }
        public bool ClientPredicate(Client pay)
        {
            return pay.Id == id;
        }
    }
}
