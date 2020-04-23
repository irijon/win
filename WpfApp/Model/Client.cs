using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string  Phone { get; set; }
        public string Status { get; set; }

        public Client() { }

        public Client(int id, string firstName,
                        string lastName, string Status, string Phone, string Email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Status = Status;
            this.Phone = Phone;
            this.Email = Email;
        }

        public Client ShallowCopy()
        {
            return (Client)this.MemberwiseClone();
        }
    }
}