using System;
using System.Globalization;
using Entities;

namespace Exercicio_Fix_LINQ {
    class Program {
        static void Main(string[] args)
        {
            string patch = @"C:\Users\Prado\Desktop\POOC#\apps\Exercicio_Fix_LINQ\estoque.txt";

            int flap = 0;
            string answer;

            Stock NewStock = new Stock(patch);

            try
            {
                do
                {
                    /**/
                    Console.Clear();
                    Console.WriteLine("Would you like:");
                    Console.WriteLine("- Print the report! ( print )");
                    Console.WriteLine("- Add or remove product! ( add or remove )");
                    Console.WriteLine("- Search ID category to print! ( search )");
                    answer = Console.ReadLine();

                    if (answer.ToLower() == "print" || answer.ToLower() == "p")
                    {
                        Console.WriteLine("\nReports: \n");
                        Console.WriteLine("ID - NAME - PRICE - QUANTITY - TOTAL PRICE - CATEGORY - TIER");
                        NewStock.PrintDocument();
                        Console.WriteLine("\nTotal stock value: " + NewStock.SomaTotalDoEstoque().ToString("F2", CultureInfo.InvariantCulture));
                    }
                    else if (answer.ToLower() == "search" || answer.ToLower() == "s")
                    {
                        Console.Write("Id category: ");
                        NewStock.SearchIdCategory();
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
