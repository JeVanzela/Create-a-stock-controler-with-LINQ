using System;
using System.Collections.Generic;
using System.IO;
using Entities;

namespace Exercicio_Fix_LINQ {
    class Program {
        static void Main(string[] args)
        {
            string patch = @"C:\Users\JEAN\Desktop\POOC#\apps\Exercicio_Fix_LINQ\estoque.txt";
            int flap = 0;
            string answer;

            Stock NewStock = new Stock(patch);

            try
            {
                do
                {
                    /**/
                    Console.WriteLine("Would you like:");
                    Console.WriteLine("     Print the report! ( y/n or exit )");
                    Console.WriteLine("     Add or remove product! ( add or remove )");
                    answer = Console.ReadLine();

                    if (answer.ToLower() == "yes" || answer.ToLower() == "y")
                    {
                        Console.WriteLine("\nReports: \n");
                        NewStock.PrintDocument();
                    }

                    else if (answer.ToLower() == "add" || answer.ToLower() == "a")
                    {
                        NewStock.AddProduct();
                    }
                    else if (answer.ToLower() == "remove" || answer.ToLower() == "r")
                    {
                        NewStock.RemoveProduct();
                    }

                    else if (answer.ToLower() == "exit" || answer.ToLower() == "e")
                    {
                        NewStock.WriterStockToDocument();
                        flap = 1;
                    }

                    Console.ReadLine();

                } while (flap != 1);
            }

            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
    }
}
