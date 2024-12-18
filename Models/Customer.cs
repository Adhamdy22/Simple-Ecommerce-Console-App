using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return $"ID:{ID},Name:{Name},Address:{Address}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Customer))
                return false;

            Customer other = obj as Customer;
            return this.ID == other.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
