using System.Collections.Generic;
using System.Globalization;

namespace Entities {
    class Products{

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int IDCategory { get; set; }
        public Category Category { get; set; }

        List<Category> CategoriesList = new List<Category>()
        {
            new Category(1, "Tols", 2),
            new Category(2, "Games", 1),
            new Category(3, "Eletronics", 1),
            new Category(4, "Without category", 0)
        };

        public Products(int id, string name, double price, int newCategory)
        {
            Id = id;
            Name = name;
            Price = price;

            foreach (Category c in CategoriesList)
            {
                if (c.Id == newCategory)
                {
                    Category = c;
                }
            }
        }

        public override string ToString()
        {
            return (Id + " - " +
                    Name + " - " +
                    Price.ToString("F2", CultureInfo.InvariantCulture) + " - " +
                    Category.Name + " - " +
                    Category.Tier);
        }
    }
}
