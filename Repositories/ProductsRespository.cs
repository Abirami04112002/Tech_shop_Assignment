using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Exceptions;
using Task_1.model;

namespace Task_1.Repositories
{
    internal class ProductsRespository
    {
        public static List<Products> Products=new List<Products>();
        Products products=new Products();   

        public void InsertProduct()
        {
            try
            {
                Console.WriteLine("Enter ProductID: ");
                int ProductID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product Name: ");
                string ProductName = Console.ReadLine();
                Console.WriteLine("Enter Description of the Product: ");
                string Description = Console.ReadLine();
                Console.WriteLine("Enter Price of the Product: ");
                decimal Price = decimal.Parse(Console.ReadLine());
                products = new Products(ProductID, ProductName, Description, Price);
                InvalidProductDataException.InvalidProductException(products);
                DuplicateProductIDExceptioncs.DuplicateId(ProductID);
                Products.Add(products);

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            
        }
        public void GetProductDetails()

        {
            try
            {
                Console.WriteLine("Enter ProductID to get: ");
                int ProductId = int.Parse(Console.ReadLine());
                ProductNotFoundException.ProductNotFound(ProductId);
                foreach (Products products in Products)
                {
                    if (products.ProductID == ProductId)
                    {
                        Console.WriteLine(products);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            
        }
        public void UpdateProductInfo()
        {
            try
            {
                Console.WriteLine("Enter Product Id to update: ");
                int ProductID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the updated Product ID:");
                int UpdatedID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the update Product Name");
                string UpdatedName = Console.ReadLine();
                Console.WriteLine("Enter the updated Product Description");
                string UpdatedDescription = Console.ReadLine();
                Console.WriteLine("Enter the Updated PRice");
                decimal UpdatedPrice = decimal.Parse(Console.ReadLine());
                products = new Products(UpdatedID, UpdatedName, UpdatedDescription, UpdatedPrice);
                InvalidProductDataException.InvalidProductException(products);
                foreach (Products p in Products)
                {
                    if (p.ProductID == ProductID)
                    {
                        p.ProductID = products.ProductID;
                        p.ProductName = products.ProductName;
                        p.Description = products.Description;
                        p.Price = products.Price;
                    }
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            
        }
        public void IsProductInStock()
        {
            try
            {
                Console.WriteLine("Enter ProductID : ");
                int Productid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Quantity of the Product to check availability:");
                int quantity = int.Parse(Console.ReadLine());
                ProductNotFoundException.ProductNotFound(Productid);
                foreach (Inventory inventory in InventoryRepository.Inventories)
                {
                    if (inventory.Products.ProductID == Productid)
                    {
                        if (inventory.QuantityInStock > quantity) Console.WriteLine("Product Available");
                        else Console.WriteLine("Product Unavailable");
                    }
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }

    }
}
