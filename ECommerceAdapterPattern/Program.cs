namespace ECommerceAdapterPattern
{
    //The above code demonstrates the Adapter Design Pattern using an interface in a C# program for an e-commerce website. The user can select from a list of operations such as adding, removing, or updating customers or orders. The user can also retrieve a list of customers or orders. The code uses a try-catch block to handle errors if the user inputs invalid data. If the user selects an invalid option, the program will prompt the user to try again. After each operation, the program asks the user if they want to try again without exiting the program.
    interface ICustomer
    {
        void GetCustomers();
        void AddCustomer(string name, int age);
        void RemoveCustomer(string name);
        void UpdateCustomer(string name, int age);
    }

    interface IOrder
    {
        void GetOrders();
        void AddOrder(string product, int quantity);
        void RemoveOrder(string product);
        void UpdateOrder(string product, int quantity);
    }

    class ECommerceSystem : ICustomer, IOrder
    {
        private Dictionary<string, int> customers;
        private Dictionary<string, int> orders;

        public ECommerceSystem()
        {
            customers = new Dictionary<string, int>();
            orders = new Dictionary<string, int>();
        }

        public void GetCustomers()
        {
            Console.WriteLine("Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine("Name: {0}, Age: {1}", customer.Key, customer.Value);
            }
        }

        public void AddCustomer(string name, int age)
        {
            customers.Add(name, age);
            Console.WriteLine("Customer added successfully");
        }

        public void RemoveCustomer(string name)
        {
            if (customers.ContainsKey(name))
            {
                customers.Remove(name);
                Console.WriteLine("Customer removed successfully");
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }

        public void UpdateCustomer(string name, int age)
        {
            if (customers.ContainsKey(name))
            {
                customers[name] = age;
                Console.WriteLine("Customer updated successfully");
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }

        public void GetOrders()
        {
            Console.WriteLine("Orders:");
            foreach (var order in orders)
            {
                Console.WriteLine("Product: {0}, Quantity: {1}", order.Key, order.Value);
            }
        }

        public void AddOrder(string product, int quantity)
        {
            orders.Add(product, quantity);
            Console.WriteLine("Order added successfully");
        }

        public void RemoveOrder(string product)
        {
            if (orders.ContainsKey(product))
            {
                orders.Remove(product);
                Console.WriteLine("Order removed successfully");
            }
            else
            {
                Console.WriteLine("Order not found");
            }
        }

        public void UpdateOrder(string product, int quantity)
        {
            if (orders.ContainsKey(product))
            {
                orders[product] = quantity;
                Console.WriteLine("Order updated successfully");
            }
            else
            {
                Console.WriteLine("Order not found");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ECommerceSystem ecommerce = new ECommerceSystem();
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Select operation:");

                Console.WriteLine("1. Get Customers\n2. Add Customer\n3. Remove Customer\n4. Update Customer\n5. Get Orders\n6. Add Order\n7. Remove Order\n8. Update Order\n9. Exit");

                Console.Write("Enter your choice: ");

                int choice = 0;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input. Try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ecommerce.GetCustomers();
                        break;
                    case 2:
                        Console.Write("\nEnter customer name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter customer age: ");
                        int age = 0;
                        try
                        {
                            age = int.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid input. Try again.");
                            break;
                        }
                        ecommerce.AddCustomer(name, age);
                        break;
                    case 3:
                        Console.Write("Enter customer name: ");
                        name = Console.ReadLine();
                        ecommerce.RemoveCustomer(name);
                        break;
                    case 4:
                        Console.Write("Enter customer name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter customer age: ");
                        age = 0;
                        try
                        {
                            age = int.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid input. Try again.");
                            break;
                        }
                        ecommerce.UpdateCustomer(name, age);
                        break;
                    case 5:
                        ecommerce.GetOrders();
                        break;
                    case 6:
                        Console.Write("Enter product name: ");
                        string product = Console.ReadLine();
                        Console.Write("Enter quantity: ");
                        int quantity = 0;
                        try
                        {
                            quantity = int.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid input. Try again.");
                            break;
                        }
                        ecommerce.AddOrder(product, quantity);
                        break;
                    case 7:
                        Console.Write("Enter product name: ");
                        product = Console.ReadLine();
                        ecommerce.RemoveOrder(product);
                        break;
                    case 8:
                        Console.Write("Enter product name: ");
                        product = Console.ReadLine();
                        Console.Write("Enter quantity: ");
                        quantity = 0;
                        try
                        {
                            quantity = int.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid input. Try again.");
                            break;
                        }
                        ecommerce.UpdateOrder(product, quantity);
                        break;
                    case 9:
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
                Console.WriteLine();
                Console.Write("Do you want to try again? (y/n) ");
                string response = Console.ReadLine();

                if (response == "y")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                }
            }
        }

    }
}

