using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace Entities {
    class Stock {

        public string Patch { get; set; }
        public List<Products> ProductList { get; set; }
        public int count { get; set; }

        public Stock(string patch)
        {
            Patch = patch;
            ProductList = new List<Products>();
            count = 1;

            ReaderDocumentToStock();
        }

        public void ReaderDocumentToStock()
        {
            //Abre e garante que vai ser encerrado
            using (StreamReader Sr = File.OpenText(Patch))
            {
                while (!Sr.EndOfStream)
                {
                    //Lê arquivo
                    string[] divisor = Sr.ReadLine().Split(", ");

                    //Cria um Produto no estoque
                    ProductList.Add(new Products(int.Parse(divisor[0]), divisor[1], double.Parse(divisor[2]), int.Parse(divisor[3])));
                    IncrementarIdCount();
                }
            }
        }

        public void WriterStockToDocument()
        {
            using (StreamWriter Sw = File.CreateText(Patch))
            {
                foreach (Products p in ProductList)
                {

                    Sw.WriteLine(p.Id + ", " +
                                 p.Name.ToUpper() + ", " +
                                 p.Price.ToString("F2", CultureInfo.CurrentCulture) + ", " +
                                 p.Category.Id);
                }
            }
        }

        public void AddProduct()
        {
            Console.WriteLine("Please! Enter the following information: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Price, Ex. 0000,00: ");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("\nCategory Id ( NUMBER ):\n" +
                              "     1 - Tols\n" +
                              "     2 - Games\n" +
                              "     3 - Eletronics");
            int idCategory = VerificandoIdCategory(Console.ReadLine());

            ProductList.Add(new Products(VerificandoIdProduct(), name, price, idCategory));

            Console.WriteLine();
            PrintDocument();
            WriterStockToDocument();
        }

        public void RemoveProduct()
        {
            Console.Write("Please! Enter ID for to remove: ");
            int idTemp = int.Parse(Console.ReadLine());

            if (idTemp > 0 && idTemp <= count)
            {
                foreach (Products p in ProductList)
                {
                    if (p.Id == idTemp)
                    {
                        Console.WriteLine();
                        Console.WriteLine("\n" + p);
                        Console.WriteLine("\nDo you want to delete? y/n");
                        string vaiDeletar = Console.ReadLine().ToLower();

                        if (vaiDeletar == "y" || vaiDeletar == "yes")
                        {
                            ProductList.Remove(p);
                            DecrementarIdCount();

                            foreach (Products pTemp in ProductList)
                            {
                                if (pTemp.Id > idTemp)
                                {
                                    pTemp.Id--;
                                }
                            }
                            break;
                        } 
                    }
                }
            }
            else
            {
                Console.WriteLine("The product does not exist.");
            }

            WriterStockToDocument();
        }

        public int VerificandoIdCategory(string id)
        {
            int numberId = 0;
            id = id.ToLower();

            if (id == "tols" || id == "t")
            {
                numberId = 1;
            }
            else if (id == "games" || id == "g")
            {
                numberId = 2;
            }
            else if (id == "eletronics" || id == "e")
            {
                numberId = 3;
            }
            else if (numberId != 0)
            {
                numberId = 4;
            }
            else
            {
                for (int i = 1; i < 4; i++)
                {
                    if (int.Parse(id) == i)
                    {
                        numberId = int.Parse(id);
                    }
                }
            }
            return numberId;
        }
        public int VerificandoIdProduct()
        {
            foreach (Products p in ProductList)
            {
                if (p.Id == count)
                {
                    IncrementarIdCount();
                }
            }
            return count;
        }
        public void IncrementarIdCount()
        {
            count++;
        }

        public void DecrementarIdCount()
        {
            count--;
        }

        public void PrintDocument()
        {
            foreach (Products p in ProductList)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
