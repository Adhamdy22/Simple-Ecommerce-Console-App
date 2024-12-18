using Managers;
using Models;

namespace ITI.Day6
{
    public static class Program
    {
        public static void Start()
        {
            try
            {
                Console.WriteLine("Hello");
                Console.WriteLine("Choose: 1-Customer 2-Order");
                int start = int.Parse(Console.ReadLine());
                switch (start)
                {
                    case 1:
                        Customer_Opreations();
                        break;

                    case 2:
                        Order_Opreations();
                        break;

                    default:
                        Start();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void Customer_Opreations()
        {
            try
            {
                Console.WriteLine("Choose: 1-Add Customer 2-Edit Customer 3-Delete Customer 4-Select Customers 5-Select Customer by its ID");
                int custopreation = int.Parse(Console.ReadLine());
                if (custopreation == 1)
                {
                    try
                    {
                        Console.WriteLine("Enter Customer Name");
                        string customername = Console.ReadLine();
                        Console.WriteLine("Enter Customer Address");
                        string customeraddress = Console.ReadLine();

                        CustomerManager customerManager = new CustomerManager();
                        customerManager.LoadCustomers();
                        if (customerManager.Add(new Customer() { Name = customername, Address = customeraddress }))
                        {
                            Console.WriteLine("Added Customer Sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("Customer not Added Sucessfully");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

                else if (custopreation == 2)
                {
                    try
                    {
                        Console.WriteLine("Enter Customer Name");
                        string customername = Console.ReadLine();

                        Console.WriteLine("Enter Customer id");
                        int customer_id = int.Parse(Console.ReadLine());

                        CustomerManager customerManager = new CustomerManager();
                        customerManager.LoadCustomers();
                        customerManager.Update(customer_id,new Customer() { ID = customer_id, Name = customername });
         
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

                else if (custopreation == 3)
                {
                    try
                    {
                        Console.WriteLine("Enter Customer id");
                        int customer_id = int.Parse(Console.ReadLine());

                        CustomerManager customerManager = new CustomerManager();
                        customerManager.LoadCustomers();

                        Customer c = new Customer { ID = customer_id };
                        if (customerManager.Remove(c))
                        {
                            Console.WriteLine("Customer Deleted Sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("Customer not Deleted");
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }

                else if (custopreation == 4)
                {
                    try
                    {

                        CustomerManager customerManager = new CustomerManager();
                        customerManager.LoadCustomers();
                        List<Customer> customers = customerManager.GetAll();

                        if (customers.Count > 0)
                        {
                            foreach (var customer in customers)
                            {
                                Console.WriteLine($"ID: {customer.ID}, Name: {customer.Name}, Address: {customer.Address}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No customers found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                else if (custopreation == 5)
                {
                    try
                    {
                        Console.WriteLine("Enter Customer id");
                        int customer_id = int.Parse(Console.ReadLine());


                        CustomerManager customerManager = new CustomerManager();
                        customerManager.LoadCustomers();

                        Customer customer = customerManager.GetById(customer_id);

                        if (customer != null)
                        {
                            Console.WriteLine($"ID: {customer.ID}, Name: {customer.Name}, Address: {customer.Address}");
                        }
                        else
                        {
                            Console.WriteLine("No customer found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                else
                {
                    Customer_Opreations();
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public static void Order_Opreations()
        {
            try
            {
                Console.WriteLine("Choose: 1-Add Order 2-Edit Order 3-Delete Order 4-Select Orders 5-Select Order by its ID");
                int order_opreation = int.Parse(Console.ReadLine());
                if (order_opreation == 1)
                {
                    try
                    {
                        Console.WriteLine("Enter price of order");
                        decimal price = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Customer id");
                        int customerid = int.Parse(Console.ReadLine());

                        OrderManager orderManager = new OrderManager();
                        orderManager.LoadOrders();

                        if (orderManager.Add(new Order() { Price = price, Customer = new Customer() { ID = customerid } }))
                        {
                            Console.WriteLine("Added Order Sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("Order not Added Sucessfully");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

                else if (order_opreation == 2)
                {
                    try
                    {
                        Console.WriteLine("Enter order price");
                        decimal price = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("Enter order id");
                        int order_id = int.Parse(Console.ReadLine());

                        OrderManager orderManager = new OrderManager();
                        orderManager.LoadOrders();
                        orderManager.Update(order_id, new Order() { ID = order_id, Price = price });
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (order_opreation == 3)
                {
                    try
                    {
                        Console.WriteLine("Enter order id");
                        int order_id = int.Parse(Console.ReadLine());

                        OrderManager orderManager = new OrderManager();
                        orderManager.LoadOrders();

                        if (orderManager.Remove(new Order { ID=order_id}))
                        {
                            Console.WriteLine("Order Deleted Sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("Order not Deleted");
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }


                }

                else if (order_opreation == 4)
                {
                    try
                    {

                        OrderManager ordermanager = new OrderManager();
                        ordermanager.LoadOrders();

                        List<Order> orders = ordermanager.GetAll();

                        if (orders.Count > 0)
                        {
                            foreach (var order in orders)
                            {
                                Console.WriteLine($"orderid: {order.ID}, Date: {order.Date} , price: {order.Price} ,CustomerId:{order.Customer.ID}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No orders found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                else if (order_opreation == 5)
                {
                    try
                    {
                        Console.WriteLine("Enter order id");
                        int order_id = int.Parse(Console.ReadLine());

                        OrderManager orderManager = new OrderManager();

                        orderManager.LoadOrders();

                        Order order = orderManager.GetById(order_id);

                        if (order != null)
                        {
                            Console.WriteLine($"ID: {order.ID}, price: {order.Price}, CustomerId: {order.Customer.ID}");
                        }
                        else
                        {
                            Console.WriteLine("No orders found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                else
                {
                    Order_Opreations();
                }








            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static int Main()
        {
            #region
            //Customer c1 = new Customer { ID = 10, Name = "Adham", Address = "Aswan" };
            //Customer c2 = new Customer { ID = 20, Name = "Hassan", Address = "Aswan" };
            //Customer c3 = new Customer { ID = 30, Name = "Mohamed", Address = "Aswan" };
            //Customer c4 = new Customer();

            ////List<Customer> CustomersList = new List<Customer> { c1, c2, c3 };

            //CustomerManager customermanage = new CustomerManager();

            //customermanage.LoadCustomers();

            //customermanage.Add(c1);
            //customermanage.Add(c2);
            //customermanage.Add(c3);
            //customermanage.Add(c4);
            //customermanage.Update(30, new Customer { Name = "Abdelhakem", Address = "Sohag" });
            //customermanage.Update(30, new Customer { Name = "Moamen", Address = "Luxor" });
            //customermanage.Add(new Customer { ID = 100, Name = "Shabaan", Address = "Nasr el Nouba" });

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            ////customermanage.Remove(c1);
            //Console.WriteLine(customermanage.GetById(30));
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //foreach (Customer customer in customermanage.GetAll())
            //{
            //    Console.WriteLine(customer.Name);
            //}
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();



            //Order o1 = new Order { ID = 10, Price = 3000, Customer = new Customer { ID = 100 } };
            //Order o2 = new Order { ID = 20, Price = 50000, Customer = new Customer { ID = 20 } };
            //Order o3 = new Order { ID = 30, Price = 200000, Customer = new Customer { ID = 30 } };


            //List<Order> OrderList = new List<Order> { o1, o2, o3 };

            //OrderManager ordermanage = new OrderManager();

            //ordermanage.LoadOrders();
            //ordermanage.Add(o1);

            ////ordermanage.Add(o1);
            ////ordermanage.Add(o2);
            ////ordermanage.Add(o3);
            ////ordermanage.Remove(o1);

            ////ordermanage.Update(20, new Order { Price = 600000, Customer = new Customer { ID = 20 } });
            ////ordermanage.Update(20, new Order { Price = 500, Customer = new Customer { ID = 40 } });


            //foreach (Order order in ordermanage.GetAll())
            //{
            //    Console.WriteLine(order);
            //}

            ////Console.WriteLine(ordermanage.GetById(20));
            ///
            #endregion

            Start();


            return 0;
        }
    }
}
