using System;
using System.IO;

namespace carpetshop
{
    class Program
    {
        static string[] types = { "Wool", " Artifical FIbre", "Mixed" };
        static double[] Price = { 42.99, 18.99, 28.99 };
        static string carpet = "";
        static string colour = "";
        static string cost = "";
        static string name = "";
        static int carpetType = 0;
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome To Bob's Carpet Emporium");
            Console.WriteLine(" ");
            Console.WriteLine("Enter Your Name");
            name = Console.ReadLine();


            carpetOptions();
         tryAgain:
            try
            {
                carpetType = int.Parse(Console.ReadLine());
                if (carpetType > 3 || carpetType <= 0)
                {
                    Console.WriteLine("Please enter a valid option, 1,2 0r 3");
                    carpetOptions();
                    carpetType = int.Parse(Console.ReadLine());
                }
                else if (carpetType == 1)
                {
                    carpet = types[0];
                }
                else if (carpetType == 2)
                {
                    carpet = types[1];
                }
                else if (carpetType == 3)
                {
                    carpet = types[2];
                }
            }
            catch
            {
                Console.WriteLine("please enter a number");
                goto tryAgain;
            }


            Console.WriteLine(" Please enter the colour of carpet: ");
            colour = Console.ReadLine();

        retry:
            Console.WriteLine(" carpet comes in 4m widts \n Please enter the number of metres length you require: ");
            try
            {
                double length = int.Parse(Console.ReadLine());
                if (length < 1)
                {
                    Console.WriteLine("enter a number greater than 0");
                    goto retry;
                }
                double totalCost = 4 * length * Price[carpetType - 1];
                cost = totalCost.ToString("0.00");
            }
            catch
            {
                Console.WriteLine("enter a number");
                goto retry;
            }


            customerChoice();

            Console.WriteLine(" enter y to proceed or any other key to go back to main menu");
            string userChoice = Console.ReadLine();
            if (userChoice == "y")
            {
                printReceipt();
            }
            else
            {
                Console.Clear();
            }

        }
        static void carpetOptions()
        {
            Console.WriteLine("What type of carpet would you like?");
            Console.WriteLine("1 - wool (£42.99 per sqaure metre");
            Console.WriteLine("2 - Artificial Fibre (£18.99 per sqaure metre");
            Console.WriteLine("3 - Mixed (£28.99 per sqaure metre");
        }
        static void customerChoice()
        {
            Console.WriteLine("you have selected " + carpet.ToUpper() + " in " + colour.ToUpper());
            Console.WriteLine("TOTAL COST = £" + cost);
        }
        static void printReceipt()
        {
            StreamWriter Filewriter = new StreamWriter("carpetshopfile.txt", true);
            DateTime today = DateTime.Today;
            Filewriter.WriteLine("ORDER DATE : " + today.ToString("dd/MM/yyyy"));
            Filewriter.WriteLine("Customer Name : " + name);
            Filewriter.WriteLine("Carpet Type : " + carpet.ToUpper() + " in " + colour.ToUpper());
            Filewriter.WriteLine("Total Cost : " + cost);
            Filewriter.Close();

        }
    }
}
