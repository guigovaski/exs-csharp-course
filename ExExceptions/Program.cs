﻿using System.Globalization;
using ExExceptions.Entities.Exceptions;
using ExExceptions.Entities;

namespace ExExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data:");

                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine()!);

                Console.Write("Holder: ");
                string holder = Console.ReadLine()!;

                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                Console.Write("Withdraw limit");
                double widthdraw = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                Account account = new Account(number, holder, balance, widthdraw);

                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                account.Withdraw(amount);

                Console.WriteLine("New balance: " + account.Balance.ToString("F2"));
            }
            catch (DomainException e)
            {
                Console.WriteLine("Error: " + e.Message);                
            }  
        }
    }
}
