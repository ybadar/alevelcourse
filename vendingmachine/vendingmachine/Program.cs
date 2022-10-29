using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vendingmachine
{
    class Program
    {
       static string[] items = { "twix", "skittles", "cheese and onion crips" };
        // array for item list 
        static double[] prices = { 2.35, 4.30, 3.00 };
        // array for prices of each item with the index of the price corresponding to the index of the item
        static double[] coinsAllowed = { 0.0,0.05, 0.10, 0.20, 0.50, 1.00, 2.00 };
        // array for the coins which are allowed this used later onin validation checking to make sure the correct coins have been entered
        static double balance = 0.0;
        // varibale for balance defined here as nothing as this varibale changes throughout

        static void Main(string[] args)
        {
            string userChoice = " ";
            // variable userChoice set as nothing as it will be changed later when the user chooses in the menu

            Console.WriteLine("Welcome to the vending machine");
            Console.WriteLine();
            // welcoming the user to the vending machine

            printItems();
            // method used to call on subprogram to output the list of items available

            printOptions();
            // method used to call subprogram to output the options the user has

            userChoice = Console.ReadLine();
            // reads the input of the user and is stored in the variable userChoice
            bool end = false;
            while (!end)
            // while loop to loop the vending machine so the user can exit options and switch t0 other options aswell as refreshing for the next user
            {
                switch (userChoice)  // switch case used to process the choice the user has inputted and display the correct option
                {
                    case "1":
                        selectProduct(ref balance); // method selectProduct used to call subprogram
                        break;
                    case "2":
                        insertCoins(ref balance); // method insertCoins used to call subprogram
                        break;
                    case "3":
                        exit(); // method used so the user can exit
                        end = true;
                        break;
                    default:
                        Console.WriteLine("Invalid entry!");
                       // validation to prevent the code from crashing and to encourage the user to input correct information
                        break;

                }
                printItems();
                printOptions();  // each method called again in the loop so the next user can access the vending machine
                getBalance();
                
                userChoice = Console.ReadLine(); // user input is read again and stored into userChoice
            }
        }
        static void printOptions() // subprogram to print the options the user has
        {
            Console.WriteLine("  ");
            Console.WriteLine("Choose Option:");
            Console.WriteLine("1. Select Product"); // options displayed
            Console.WriteLine("2. Insert Coins");
            Console.WriteLine("3. Exit");
        }
        static void printItems()
        {
            for (int i = 0; i < items.Length; i++) // count controlled loop to display the item code,item and price
            {
                Console.WriteLine("item code: " + i + " " + items[i] + " " + "£" + prices[i]);
                // item code is the position in the array
            }
        }
        static double insertCoins(ref double balance)
            // ref changes the balance everywhere not just in this scope so it is a global variable
        {
            tryAgain:
            double coin = 0.0;
            try // any unexpected inputs are dealt with to prevent the porgram from crashing
            {
                do
                {
                    // condition controlled loop so the user can keep entering coins until "0" is entered to exit
                    Console.WriteLine("insert coin, enter 0 to exit");
                    coin = double.Parse(Console.ReadLine());
                    if (coinsAllowed.Contains(coin))
                    {
                        balance = balance + coin; // coin entered is added to the balance
                        Console.WriteLine("balance is: " + balance);
                    }
                    else
                    {
                        Console.WriteLine("This coin is not accepted");
                    }
                }
                while (coin > 0);

            }
            catch (Exception) // error is catched and message is displayed
            {
                Console.WriteLine("enter valid coin");
                goto tryAgain ; // user is sent back to the waypoint marked as tryAgain and prompted to enter a valid coin
            }
            return balance;
        }
        static void selectProduct(ref double balance)
        {
            retry3:
            try
            {
                retry:
                Console.WriteLine("enter the product code of the item you wish to buy");
                int itemCode = int.Parse(Console.ReadLine());

                if (items.Length - 1 > itemCode)
                {
                    Console.WriteLine("item chosen: " + items[itemCode] + " " + "£" + prices[itemCode]);
                retry2:
                    Console.WriteLine("Would you like to purchase? yes or no");
                    string answer = Console.ReadLine();
                    answer.ToLower();
                    if (answer == "yes" && balance > prices[itemCode])
                    {
                        balance = balance - prices[itemCode];
                        Console.WriteLine("thank you for your purchase");
                        Console.WriteLine("change due: " + balance);
                        balance = 0.0;

                    }
                    else if (answer == "no")
                    {
                        Console.WriteLine("select another product");
                    }
                    else if (balance < prices[itemCode])
                    {
                        Console.WriteLine("You have insufficient funds, please enter more coins");
                    }
                    else
                    {
                        Console.WriteLine("please enter yes or no ");
                        goto retry2;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Entry!, try again");
                    goto retry;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Entry, Please enter the product code.");
                goto retry3;
            }
        }
        static void exit()
        {
            Console.WriteLine("Goodbye!");

        }
        static void getBalance()
        {
            Console.WriteLine("Your Balance is: "+"£"+balance);
        }
        
        
    }
}
