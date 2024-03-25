using System.Xml.Serialization;
using Task_1.Exceptions;
using Task_1.model;
using Task_1.Repositories;

namespace Task_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            ProductsRespository productsRespository = new ProductsRespository();
            OrdersRepository ordersRepository = new OrdersRepository();
            OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository();
            InventoryRepository inventoryRepository = new InventoryRepository();
            int choice1 = 0,choice2=0,choice3=0,choice4=0, choice5=0,choice6=0;
            do
            {
                Console.Clear();
                Console.WriteLine("******Main Menu********");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: Customers\n2: Products\n3: Orders\n4: OrderDetails\n5: Inventory\n6: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice1 = int.Parse( Console.ReadLine() );
                switch ( choice1 )
                {
                    case 1:
                        Console.Clear();
                        do
                        {
                            Console.WriteLine("****Customer Details****");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine($"1: AddCustomer\n2: CalculateTotalOrder\n3: GetCustomerInfo\n4. UpdateCustomerDetails\n5: Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice2 = int.Parse(Console.ReadLine());
                            switch (choice2)
                            {

                                case 1:
                                    customerRepository.AddCustomer();
                                    break;

                                case 2:
                                    customerRepository.CalculateTotalOrders();
                                    break;

                                case 3:
                                    customerRepository.GetCustomerDetails();
                                    break;

                                case 4:
                                    customerRepository.UpdateCustomerInfo();
                                    break;

                                case 5:
                                    Console.WriteLine("Exiting...");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;        
                            }
                        } while (choice2 != 5);
                        break;

                    case 2:
                        Console.Clear();
                        Products products = new Products();
                        do
                        {
                            Console.WriteLine("****List of Products****");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine($"1: Insert Product\n2: Get Product Details\n3: Update Product\n4: check stock availability\n5: Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice3 = int.Parse(Console.ReadLine());
                            switch (choice3)
                            {
                                case 1:
                                    productsRespository.InsertProduct();
                                    break;

                                case 2:
                                    productsRespository.GetProductDetails();
                                    break;

                                case 3:
                                    productsRespository.UpdateProductInfo();
                                    break;

                                case 4:
                                    productsRespository.IsProductInStock();
                                    break;

                                case 5:
                                    Console.WriteLine("Exiting... ");
                                    break;

                                default:
                                    Console.WriteLine("Provide the valid Input");
                                    break;
                            }
                        } while (choice3 != 5);
                        break;

                    case 3:
                        Console.Clear();
                        Orders orders = new Orders();
                        do
                        {
                            Console.WriteLine("*****Orders Placed****");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine($"1: InsertOrders\n2: CalculateTotalAmount\n3: GetOrderDetails\n4: UpdateOrderStatus\n5: CancelOrders\n6: Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice4 = int.Parse(Console.ReadLine());
                            switch (choice4)
                            {
                                case 1:
                                   ordersRepository.InsertOrder();
                                   break;

                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Enter Order ID: ");
                                        int orderID = int.Parse(Console.ReadLine());
                                        OrderNotFoundException.OrderNotFound(orderID);
                                        ordersRepository.CalculateTotalAmount(orderID);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 3:
                                    try
                                    {
                                        Console.WriteLine("Enter Order ID: ");
                                        int orderId = int.Parse(Console.ReadLine());
                                        OrderNotFoundException.OrderNotFound(orderId);
                                        ordersRepository.GetOrderDetails(orderId);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 4:
                                    try
                                    {
                                        Console.WriteLine("ProductId to be updated: ");
                                        int orderid = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter the status of the Product");
                                        string status = Console.ReadLine();
                                        OrderNotFoundException.OrderNotFound(orderid);
                                        ordersRepository.UpdateOrderStatus(orderid, status);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 5:
                                    try 
                                    { 
                                        Console.WriteLine("Enter the orderId to cancel");
                                        int orderid1 = int.Parse(Console.ReadLine());
                                        OrderNotFoundException.OrderNotFound(orderid1);
                                        ordersRepository.CancelOrder(orderid1);
                                    }
                                    catch (Exception ex1) { Console.WriteLine(ex1.Message);}
                                    break;

                                case 6:
                                    Console.WriteLine("Exiting....");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;

                            }
                        } while (choice4 != 6);
                        break;

                    case 4:
                        Console.Clear();
                        OrderDetails orderDetails = new OrderDetails();
                        do
                        {
                            Console.WriteLine("****OrderDetails****");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine($"1: Insert Order Details\n2: Calculate Sub Total\n3: Get order Detail Info\n4: Update Quantity\n5:Add Discount\n 6: Exit\n");
                            Console.WriteLine("Enter your choice: ");

                            choice5 = int.Parse(Console.ReadLine());
                            switch (choice5)
                            {
                                case 1:
                                    try
                                    {
                                        Console.WriteLine("Enter OrderDetail Id: ");
                                        int OrderdetailID = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter the Order ID");
                                        int OrderID = int.Parse(Console.ReadLine());
                                        Orders orders1 = new Orders(OrderID);
                                        Console.WriteLine("Enter Quantity: ");
                                        int quantity =int.Parse( Console.ReadLine());
                                        Console.WriteLine("Enter the ProductID ");
                                        int ProductID = int.Parse(Console.ReadLine());
                                        Products products1 = new Products(ProductID);
                                        orderDetails = new OrderDetails(OrderdetailID, orders1, quantity, products1);
                                        InvalidOrderDetailsDataException.InvalidOrderDetails(orderDetails);
                                        ProductNotFoundException.ProductNotFound(products1.ProductID);
                                        OrderNotFoundException.OrderNotFound(orders1.OrderID);
                                        orderDetailsRepository.InsertOrderDetail(orderDetails);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Enter OrderDetail ID: ");
                                        int Orderdetailid = int.Parse(Console.ReadLine());
                                        OrderDetailNotFoundException.OrderDetailNotFound(Orderdetailid);
                                        orderDetailsRepository.CalculateSubtotal(Orderdetailid);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 3:
                                    try
                                    {
                                        Console.WriteLine("Enter OrderDetailID to get Info: ");
                                        int orderdetailid1 = int.Parse(Console.ReadLine());
                                        OrderDetailNotFoundException.OrderDetailNotFound(orderdetailid1);
                                        orderDetailsRepository.GetOrderDetailInfo(orderdetailid1);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 4:
                                    try
                                    {
                                        Console.WriteLine("Enter OrderDetailID to update the Quantity: ");
                                        int orderdetailid = int.Parse( Console.ReadLine());
                                        Console.WriteLine("Enter the Quantity:: ");
                                        int Quantity = int.Parse(Console.ReadLine());
                                        OrderDetailNotFoundException.OrderDetailNotFound(orderdetailid);
                                        InvalidQuantityException.InvalidQuantity(Quantity);
                                        orderDetailsRepository.UpdateQuantity(orderdetailid,Quantity);
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message);}
                                    break;

                                case 5:
                                    try
                                    {
                                        Console.WriteLine("Enter the orderdetail ID:");
                                        int orderdetailid = int.Parse(Console.ReadLine());
                                        orderDetailsRepository.AddDiscount(orderdetailid);
                                        OrderDetailNotFoundException.OrderDetailNotFound(orderdetailid);
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message);}
                                    break;

                                case 6:
                                    Console.WriteLine("Exiting...");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice5 != 6);
                        break;

                    case 5:
                        Console.Clear();
                        Inventory inventory = new Inventory();
                        do
                        {
                            Console.WriteLine("****Inventory Details****");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine($"1: Insert Inventory Details\n2: Get Product Details\n3: Get Quantity In Stock\n4. Add Quantity to Inventory\n5: Remove from inventory\n6: Update Stock Quantity\n7: IsPRoductAvailable\n8: Get Inventory Value\n9: Get Low Stock Products\n10: Get all the OutOfStockProduct\n11: List all PRoducts\n12: Exit\n ");
                            Console.WriteLine("Enter your choice: ");

                            choice6 = int.Parse(Console.ReadLine());
                            switch (choice6)
                            {
                                case 1:
                                    try
                                    {
                                        Console.WriteLine("Enter Inventory ID: ");
                                        int Inventoryid = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Productid: ");
                                        int productid=int.Parse(Console.ReadLine());
                                        Products products1 = new Products(productid);
                                        Console.WriteLine("Enter Quantity in stock");
                                        int QuantityInStock = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Last stock update: ");
                                        string LastStockUpdate = Console.ReadLine();
                                        inventory = new Inventory(Inventoryid, products1, QuantityInStock, DateTime.Parse(LastStockUpdate));
                                        InvalidInventoryDataException.InvalidData(inventory);
                                        DuplicateInventoryIdException.DuplicateId(Inventoryid);
                                        ProductNotFoundException.ProductNotFound(products1.ProductID);
                                        inventoryRepository.InsertInventory(inventory);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Enter ProductId to get: ");
                                        int ProductID = int.Parse(Console.ReadLine());
                                        ProductNotFoundException.ProductNotFound(ProductID);
                                        inventoryRepository.GetProduct(ProductID);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 3:
                                    try
                                    {
                                        Console.WriteLine("Enter ProductId to get: ");
                                        int ProductID = int.Parse(Console.ReadLine());
                                        ProductNotFoundException.ProductNotFound(ProductID);
                                        inventoryRepository.GetQuantityInStock(ProductID);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 4:
                                    try
                                    {
                                        Console.WriteLine("Enter ProductId to add: ");
                                        int ProductID = int.Parse(Console.ReadLine());
                                        ProductNotFoundException.ProductNotFound(ProductID);
                                        Console.WriteLine("Enter the Quantity to add");
                                        int quantity = int.Parse(Console.ReadLine());
                                        inventoryRepository.AddToInventory(ProductID,quantity);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 5:
                                    try
                                    {
                                        Console.WriteLine("Enter ProductId to remove: ");
                                        int ProductID = int.Parse(Console.ReadLine());
                                        ProductNotFoundException.ProductNotFound(ProductID);
                                        Console.WriteLine("Enter the Quantity to add");
                                        int quantity = int.Parse(Console.ReadLine());
                                        inventoryRepository.RemoveFromInventory(ProductID, quantity);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 6:
                                    try
                                    {
                                        Console.WriteLine("Enter ProductId to update: ");
                                        int ProductID = int.Parse(Console.ReadLine());
                                        ProductNotFoundException.ProductNotFound(ProductID);
                                        Console.WriteLine("Enter the Quantity to add");
                                        int newquantity = int.Parse(Console.ReadLine());
                                        inventoryRepository.UpdateStockQuantity(ProductID, newquantity);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 7:
                                    try
                                    {
                                        Console.WriteLine("Enter ProductId to check available: ");
                                        int ProductID = int.Parse(Console.ReadLine());
                                        ProductNotFoundException.ProductNotFound(ProductID);
                                        Console.WriteLine("Enter the Quantity to check");
                                        int quantity = int.Parse(Console.ReadLine());
                                        inventoryRepository.IsProductAvailable(ProductID,quantity);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 8:
                                    try
                                    {
                                        Console.WriteLine("Enter ProductId to get total inventory value: ");
                                        int ProductID = int.Parse(Console.ReadLine());
                                        ProductNotFoundException.ProductNotFound(ProductID);
                                        inventoryRepository.GetInventoryValue(ProductID);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 9:
                                    try
                                    {
                                        Console.WriteLine("Enter threshold value to list low stock: ");
                                        int threshold = int.Parse(Console.ReadLine());
                                        InvalidThresholdDataException.InvalidThresholdData(threshold);
                                        inventoryRepository.ListLowStockProducts(threshold);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 10:
                                    inventoryRepository.ListOutOfStockProducts();
                                    break;

                                case 11:
                                    inventoryRepository.ListAllProducts();
                                    break;

                                case 12:
                                    Console.WriteLine("Exiting...");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice6 != 12);
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice1 != 6);
        }
    }
}
