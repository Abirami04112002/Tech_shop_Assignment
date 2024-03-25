using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Exceptions;
using Task_1.model;

namespace Task_1.Repositories
{
    internal class OrdersRepository
    {
        public static List<Orders> Orders= new List<Orders>();
        Orders orders=new Orders(); 

        public void InsertOrder()
        {
           
            try
            {
                Console.WriteLine("Enter Order ID: ");
                int Orderid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter CustomerID: ");
                int customerID = int.Parse(Console.ReadLine());
                Customers customers1 = new Customers(customerID);
                DateTime OrderDate = DateTime.Now;
                Console.WriteLine("Enter Total Amount: ");
                decimal TotalAmount = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter the status of the Order:");
                string Status = Console.ReadLine();
                orders = new Orders(Orderid, customers1, OrderDate, TotalAmount, Status);
                DuplicateOrderIdException.DuplicateOrderId(Orderid);
                InvalidOrderDataException.InvalidOrderData(orders);
                Orders.Add(orders);

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }



        }
        public void CalculateTotalAmount(int OrderID)
        {
            int totalAmount=0;
            foreach (OrderDetails orderDetails in OrderDetailsRepository.OrderDetails)
            {
                if (orderDetails.orders.OrderID == OrderID)
                {
                    totalAmount = Convert.ToInt32(orderDetails.products.Price) * orderDetails.quantity;
                }
            }
            Console.WriteLine(totalAmount);
        }
        public void GetOrderDetails(int orderid)
        {
            foreach (Orders orders in Orders)
            {
                if (orders.OrderID == orderid)
                {
                    Console.WriteLine(orders);
                    foreach(Customers customers in CustomerRepository.Customers) 
                    { 
                        if(orders.Customers.CustomerID== customers.CustomerID)
                        {
                            Console.WriteLine("CustomerName::"+ customers.FirstName);
                        }

                    }

                }
            }
        }
        public void UpdateOrderStatus(int orderid,string status)
        {
      
            foreach (Orders o in Orders)
            {
                if (o.OrderID == orderid)
                {
                    o.status = status;
                }
            }
        }
        public void CancelOrder(int orderid)
        {
            foreach (Orders o in Orders)
            {
                if (o.OrderID == orderid)
                {
                    Orders.Remove(o);
                    Console.WriteLine("Order Cancelled");
                }
            }
            
        }
    }
}
