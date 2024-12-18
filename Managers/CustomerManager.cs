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
    public class CustomerManager : BaseManager<Customer>
    {
        //private List<Customer> customers;
        public CustomerManager() : base() {

        }

        //public bool Add(Customer customer)
        //    {
        //        if (customer == null)
        //        {
        //            return false;  // Don't add null customers
        //        }

        //        var parameters = new Dictionary<string, object>
        //    {
        //        { "@name", customer.Name },
        //        { "@address", customer.Address }
        //    };

        //        int rowsAffected = ExecuteNonQuery("spAddCustomers", parameters);

        //        return rowsAffected > 0;
        //    }

        //public bool Remove(Customer customer)
        //    {
        //        if (customer == null)
        //        {
        //            return false;
        //        }

        //        var parameters = new Dictionary<string, object>
        //    {
        //        { "@id", customer.ID }
        //    };

        //        int rowsAffected = ExecuteNonQuery("spDeleteCustomer", parameters);

        //        return rowsAffected > 0;
        //    }

        //public Customer Update(int id, Customer customer)
        //    {
        //        if (customer == null)
        //        {
        //            return null;
        //        }

        //        var parameters = new Dictionary<string, object>
        //    {
        //        { "@id", id },
        //        { "@name", customer.Name },
        //    };

        //        int rowsAffected = ExecuteNonQuery("spUpdateCustomer", parameters);

        //        if (rowsAffected > 0)
        //        {
        //            return customer;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Customer update failed.");
        //            return null;
        //        }
        //    }

        //public Customer GetById(int id)
        //    {
        //        var parameters = new Dictionary<string, object>
        //    {
        //        { "@id", id }
        //    };

        //        DataSet ds = ExecuteQuery("spGetCustomerById", parameters);

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            var row = ds.Tables[0].Rows[0];
        //            return new Customer
        //            {
        //                ID = Convert.ToInt32(row["id"]),
        //                Name = row["name"].ToString(),
        //                Address = row["address"].ToString()
        //            };
        //        }
        //        else
        //        {
        //            Console.WriteLine("Customer not found.");
        //            return null;
        //        }
        //    }

        //public List<Customer> GetAll()
        //    {
        //        DataSet ds = ExecuteQuery("spGetAllCustomers");

        //        var customers = new List<Customer>();

        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            customers.Add(new Customer
        //            {
        //                ID = Convert.ToInt32(row["id"]),
        //                Name = row["name"].ToString(),
        //                Address = row["address"].ToString()
        //            });
        //        }

        //        return customers;
        //    }


        //public IEnumerable<Customer> GetAll2(IMapper mapper)
        //{
        //    customers = new List<Customer>();
        //    DataSet ds = ExecuteQuery("spGetAllCustomers");
        //    //return ds.Tables[0].Map<Customer>();
        //    return ds.Tables[0].MapWithAutoMapper<Customer>(mapper);
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







