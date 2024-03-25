using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.model;

namespace Task_1.Repositories
{
    internal class OrderDetailsRepository
    {
        public static List<OrderDetails> OrderDetails=new List<OrderDetails>();

        public void InsertOrderDetail(OrderDetails orderDetails)
        {
            OrderDetails.Add(orderDetails);
            foreach (Inventory inventory in InventoryRepository.Inventories)
            {
                if (orderDetails.products.ProductID==inventory.Products.ProductID)
                {
                    inventory.QuantityInStock--;
                }
            }
        }
        public void CalculateSubtotal( int orderdetailid)
        {
            foreach (OrderDetails orderdetails1 in OrderDetails)
            {
                if (orderdetails1.OrderDetailID == orderdetailid)
                {
                    int result = Convert.ToInt32(orderdetails1.products.Price) * orderdetails1.quantity;
                    Console.WriteLine(result);
                }
            }
        }
        public void GetOrderDetailInfo(int orderDetailsID)
        {
            foreach (OrderDetails orderDetails1 in OrderDetails)
            {
                if (orderDetails1.OrderDetailID == orderDetailsID)
                {
                    Console.WriteLine(orderDetails1);
                }
            }
        }
        public void UpdateQuantity(int orderdetailid, int updated_quantity)
        {
            foreach (OrderDetails orderDetails1 in OrderDetails)
            {
                if (orderDetails1.OrderDetailID == orderdetailid)
                {
                    orderDetails1.quantity = updated_quantity;
                }
            }
        }
        public void AddDiscount(int orderdetailsid)
        {
            decimal result = 0;
            foreach (OrderDetails orderDetails1 in OrderDetails)
            {
                if (orderDetails1.OrderDetailID == orderdetailsid)
                {
                    if(orderDetails1.orders.TotalAmount>50000)
                    {

                        decimal totalAmount = ((20 / 100) * orderDetails1.orders.TotalAmount);
                        result = (orderDetails1.orders.TotalAmount) - totalAmount;
                        Console.WriteLine("Discount Added Successfully");
                        Console.WriteLine(result);
                    }
                }
            }

        }
    }
}
