using shopapp.webui.Models;

namespace shopapp.webui.Data
{
    public class CategoryRepository
    {
        private static List<Category> _categories = Array.Empty<Category>().ToList();

        static CategoryRepository()
        {
            _categories = new()
            {
                new () {CategoryId = 1, Name = "Telefonlar", Description = "Telefon kategorisi" },
                new() { CategoryId = 2,Name = "Bilgisayar", Description = "Bilgisayar kategorisi" },
                new() { CategoryId = 3,Name = "Elektronik", Description = "Elektronik kategorisi" },
            };
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        public object GetCategories() => (_categories);

        public static void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == categoryId);

            return category;
        }
    }
}