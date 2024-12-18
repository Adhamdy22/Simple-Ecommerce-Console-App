using AutoMapper;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class OrderManager : BaseManager<Order>
    {

        public OrderManager() : base()
        {

        }
        //private List<Order> orders;

        //public OrderManager() : base() { }

        //public bool Add(Order order)
        //{
        //    if (order == null)
        //    {
        //        return false;  // Don't add null orders
        //    }

        //    var parameters = new Dictionary<string, object>
        //    {
        //        { "@price", order.Price },
        //        { "@customer_id", order.Customer.ID }  // Use only the ID of the customer
        //    };

        //    int rowsAffected = ExecuteNonQuery("spAddOrders", parameters);

        //    return rowsAffected > 0;
        //}

        //public bool Remove(Order order)
        //{
        //    if (order == null)
        //    {
        //        return false;
        //    }

        //    var parameters = new Dictionary<string, object>
        //    {
        //        { "@id", order.ID }
        //    };

        //    int rowsAffected = ExecuteNonQuery("spDeleteOrder", parameters);

        //    return rowsAffected > 0;
        //}

        //public Order Update(int id, Order order)
        //{
        //    if (order == null)
        //    {
        //        return null;
        //    }

        //    var parameters = new Dictionary<string, object>
        //    {
        //        { "@id", id },
        //        { "@price", order.Price },
        //    };

        //    int rowsAffected = ExecuteNonQuery("spUpdateOrder", parameters);

        //    if (rowsAffected > 0)
        //    {
        //        return order;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Order update failed.");
        //        return null;
        //    }
        //}

        //public Order GetById(int id)
        //{
        //    var parameters = new Dictionary<string, object>
        //    {
        //        { "@id", id }
        //    };

        //    DataSet ds = ExecuteQuery("spGetOrderById", parameters);

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        var row = ds.Tables[0].Rows[0];
        //        return new Order
        //        {
        //            ID = Convert.ToInt32(row["orderid"]),
        //            Price = Convert.ToDecimal(row["price"]),
        //            Customer = new Customer { ID = Convert.ToInt32(row["customerid"]) }  // Use only the ID of the customer
        //        };
        //    }
        //    else
        //    {
        //        Console.WriteLine("Order not found.");
        //        return null;
        //    }
        //}

        //public List<Order> GetAll()
        //{
        //    DataSet ds = ExecuteQuery("spGetAllOrders");

        //    var orders = new List<Order>();

        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        orders.Add(new Order
        //        {
        //            ID = Convert.ToInt32(row["orderid"]),
        //            Price = Convert.ToDecimal(row["price"]),
        //            Customer = new Customer { ID = Convert.ToInt32(row["customerid"]) }  // Use only the ID of the customer
        //        });
        //    }

        //    return orders;
        //}

        //public IEnumerable<Order> GetAll2(IMapper mapper)
        //{
        //    orders = new List<Order>();
        //    DataSet ds = ExecuteQuery("spGetAllOrders");
        //    //return ds.Tables[0].Map<Order>();
        //    return ds.Tables[0].MapWithAutoMapper<Order>(mapper);
        //}

        //public IEnumerator GetEnumerator()
        //{
        //    foreach (var customer in GetAll())
        //    {
        //        yield return customer;
        //    }
        //}
    }
}


