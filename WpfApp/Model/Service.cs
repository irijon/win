using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    class Service
    {
        public int Id { get; set; }
        public Double Price  { get; set; }
        public string Name { get; set; }

        public Service() { }

        public Service(int id, string Name, Double Price)
        {
            this.Id = id;
            this.Price  = Price;
            this.Name = Name;
        }
    }
}
