using System;

class Program
{



    static string[] num = new string[10];
    static string[] net = new string[10];
    static decimal[] sum = new decimal[10];
    static int index = 0;
    static string user;

    static void Main()

    {



        Console.Write("Enter your name: ");
        user = Console.ReadLine();

        while (true)

        {


            Console.WriteLine("\n=== LOAD SYSTEM ===");
            Console.WriteLine("1. Add Load");
            Console.WriteLine("2. View Load");
            Console.WriteLine("3. Update Load");
            Console.WriteLine("4. Delete Load");
            Console.WriteLine("5. Exit");
            Console.Write("Choose: ");
            string select = Console.ReadLine();

            if (select == "1")

            {


                Console.Write("Mobile: ");
                num[index] = Console.ReadLine();


                Console.Write("Network: ");
                net[index] = Console.ReadLine();



                Console.Write("Amount: ");
                sum[index] = Convert.ToDecimal(Console.ReadLine());

                index++;


                Console.WriteLine("Load Added!");
            }



            else if (select == "2")

            {

                for (int i = 0; i < index; i++)
                {


                    Console.WriteLine(i + " | " + num[i] + " | " + net[i] + " | ₱" + sum[i]);
                }
            }
            else if (select == "3")
            {
                Console.Write("Enter Index to Update: ");
                int i = Convert.ToInt32(Console.ReadLine());

                Console.Write("New Mobile: ");
                num[i] = Console.ReadLine();

                Console.Write("New Network: ");
                net[i] = Console.ReadLine();

                Console.Write("New Amount: ");
                sum[i] = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Updated!");
            }
            else if (select == "4")

            {

                Console.Write("Enter Index to Delete: ");
                int i = Convert.ToInt32(Console.ReadLine());

                num[i] = "";
                net[i] = "";
                sum[i] = 0;

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