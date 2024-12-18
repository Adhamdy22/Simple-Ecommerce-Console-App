using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        //public Customer Customer { get; set; }

        public int CustomerID { get; set; } // Store customer ID as an int
        public override string ToString()
        {
            return $"ID:{ID},Date:{Date},Price:{Price},CustomerID:{CustomerID}";
        }

        //public Order()
        //{
        //    Customer = new Customer(); // Initialize Customer to avoid null references
        //}

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Order))
                return false;

            Order other = obj as Order;
            return this.ID == other.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
