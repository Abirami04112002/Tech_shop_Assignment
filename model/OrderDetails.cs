﻿using System.Diagnostics;

namespace Task_1.model
{
    internal class OrderDetails
    {
        public int OrderDetailID {  get; set; }
        public Orders orders {  get; set; }
        public int quantity { get; set; }   
        public Products products {  get; set; }


        public OrderDetails()
        {

        }

        public OrderDetails(int orderDetailID, Orders orderId, int quantity, Products products)
        {
            this.OrderDetailID = orderDetailID;
            this.orders = orderId;
            this.quantity = quantity;
            this.products = products;
        }

      

        public override string ToString()
        {
            return $"OrderDetailsID:: {OrderDetailID}\t orderID:: {orders.OrderID}\t Quantity:: {quantity}\t ProductName::{products.ProductName}";
        }

        
    }
}
