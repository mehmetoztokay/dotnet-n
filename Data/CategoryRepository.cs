using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopapp.webui.Models;

namespace shopapp.webui.Data
{
    public class CategoryRepository
    {
        private static List<Category> _categories = null;

        static CategoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category() {CategoryId = 1, Name = "Telefonlar", Description = "Telefon kategorisi" },
                new Category() { CategoryId = 2,Name = "Bilgisayar", Description = "Bilgisayar kategorisi" },
                new Category() { CategoryId = 3,Name = "Elektronik", Description = "Elektronik kategorisi" },
            };
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        public static void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public static Category GetCategoryById(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

    }
}