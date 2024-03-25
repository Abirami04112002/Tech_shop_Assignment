using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Exceptions;
using Task_1.model;

namespace Task_1.Repositories
{
    internal class CustomerRepository
    {
        public static List<Customers> Customers = new List<Customers>();
        Customers customers=new Customers();

        public void AddCustomer()
        {
            try
            {
                Console.WriteLine("Enter Customer id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter first name: ");
                string Firstname = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                string Lastname = Console.ReadLine();
                Console.WriteLine("Enter email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter phone number ");
                string PhoneNumber = Console.ReadLine();
                Console.WriteLine("Enter Address: ");
                string Address = Console.ReadLine();
                customers = new Customers(id, Firstname, Lastname, email, PhoneNumber, Address);
                InvalidCustomerDataException.InvalidCustomerData(customers);
                Customers.Add(customers);
                Console.WriteLine("Customer added successfully");
                Console.WriteLine();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }    
        }
        public void CalculateTotalOrders()
        {
            try
            {
                Console.WriteLine("Enter Customer Id: ");
                int customerID = int.Parse(Console.ReadLine());
                CustomerNotFoundExceptioncs.CustomerNotFound(customerID);
                int count = 0;
                foreach (Orders orders1 in OrdersRepository.Orders)
                {
                    if (orders1.Customers.CustomerID == customerID)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Total Order Made by Customer::{customerID} is {count}");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void GetCustomerDetails()
        {
            try
            {
                Console.WriteLine("Enter Customer ID to get info: ");
                int CustomerID = int.Parse(Console.ReadLine());
                CustomerNotFoundExceptioncs.CustomerNotFound(CustomerID);
                foreach (Customers customers1 in Customers)
                {
                    if (customers1.CustomerID == CustomerID)
                    {
                        Console.WriteLine(customers1);
                    }
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void UpdateCustomerInfo()
        {
            try
            {

                Console.WriteLine("Enter Customer id to be updated: ");
                int CustomerID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the updated ID");
                int UpdatedCustomerID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter first name: ");
                string UpdatedFirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                string UpdatedLastName = Console.ReadLine();
                Console.WriteLine("Enter updated EmailID ");
                string UpdatedEmail = Console.ReadLine();
                Console.WriteLine("Enter Updated PhoneNumber ");
                string UpdatedPhoneNumber = Console.ReadLine();
                Console.WriteLine("Enter updated Address ");
                string UpdatedAddress = Console.ReadLine();
                Customers customers1 = new Customers(UpdatedCustomerID, UpdatedFirstName, UpdatedLastName, UpdatedEmail, UpdatedPhoneNumber, UpdatedAddress);
                InvalidCustomerDataException.InvalidCustomerData(customers1);
                foreach (Customers customer in Customers)
                {
                    if (customer.CustomerID == CustomerID)
                    {
                        customer.CustomerID = customers1.CustomerID;

                        customer.FirstName = customers1.FirstName;

                        customer.LastName = customers1.LastName;

                        customer.email = customers1.email;

                        customer.phoneNumber = customers1.phoneNumber;

                        customer.address = customers1.address;

                    }
                }
                foreach (Customers customer in Customers)
                {
                    if (customer.CustomerID == CustomerID)
                    {
                        Console.WriteLine(customer);
                    }
                }
                Console.WriteLine("Record updated successfully");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


            
            
        }
    }
}
