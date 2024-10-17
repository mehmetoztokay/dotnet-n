using Microsoft.EntityFrameworkCore;
using shopapp.data.Concrete.EFCore;
using shopapp.entity;

namespace shopapp.data.Concrete.EFCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            ShopContext context = new();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                    context.SaveChanges();
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.SaveChanges();
                }
            }
        }

        private static Category[] Categories = {
            new Category(){Name = "Telefon"},
            new Category(){Name = "Bilgisayar" },
            new Category(){Name = "Elektronik" }
        };

        private static Product[] Products = {
            new Product(){Name = "Samsung S5", Price = 2000, ImageUrl = "1.jpg", Description= "1 Fena Degil", IsApproved = true},
            new Product(){Name = "Samsung S6", Price = 3000, ImageUrl = "1.jpg", Description= "2 Fena Degil", IsApproved = false},
            new Product(){Name = "Samsung S7", Price = 4000, ImageUrl = "1.jpg", Description= "3 Fena Degil", IsApproved = true},
            new Product(){Name = "Samsung S8", Price = 5000, ImageUrl = "1.jpg", Description= "4 Fena Degil", IsApproved = false},
            new Product(){Name = "Samsung S9", Price = 6000, ImageUrl = "1.jpg", Description= "5 Fena Degil", IsApproved = true},
        };

    }
}