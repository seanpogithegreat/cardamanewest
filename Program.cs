using System;
using TransactionData;
using TransactionModel;

class Program
{
    static void Main()
    {
        DataService service = new DataService();
        service.LoadTransactions();

        Console.Write("Enter your name: ");
        string user = Console.ReadLine() ?? "";

        while (true)
        {
            Console.WriteLine("\n=== LOAD SYSTEM ===");
            Console.WriteLine("1. Add Load");
            Console.WriteLine("2. View Load");
            Console.WriteLine("3. Update Load");
            Console.WriteLine("4. Delete Load");
            Console.WriteLine("5. Exit");
            Console.Write("Choose: ");

            string select = Console.ReadLine() ?? "";

            if (select == "1")
            {
                Console.Write("Mobile: ");
                string mobile = Console.ReadLine() ?? "";

                Console.Write("Network: ");
                string network = Console.ReadLine() ?? "";

                Console.Write("Amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                service.Add(mobile, network, amount);

                Console.WriteLine("Load Added!");
            }
            else if (select == "2")
            {
                var loads = service.GetAll();

                for (int i = 0; i < loads.Count; i++)
                {
                    Console.WriteLine(i + " | " +
                        loads[i].MobileNumber + " | " +
                        loads[i].Network + " | ₱" +
                        loads[i].Amount);
                }
            }
            else if (select == "3")
            {
                Console.Write("Enter Index to Update: ");
                int i = Convert.ToInt32(Console.ReadLine());

                Console.Write("New Mobile: ");
                string mobile = Console.ReadLine() ?? "";

                Console.Write("New Network: ");
                string network = Console.ReadLine() ?? "";

                Console.Write("New Amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                var updatedLoad = new Load
                {
                    MobileNumber = mobile,
                    Network = network,
                    Amount = amount
                };

                service.Update(i, updatedLoad);

                Console.WriteLine("Updated!");
            }
            else if (select == "4")
            {
                Console.Write("Enter Index to Delete: ");
                int i = Convert.ToInt32(Console.ReadLine());

                service.Delete(i);

                Console.WriteLine("Deleted!");
            }
            else if (select == "5")
            {
                Console.WriteLine($"Come back again, {user}!");
                break;
            }
        }
    }
}