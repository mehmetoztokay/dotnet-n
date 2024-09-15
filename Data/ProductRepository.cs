using shopapp.webui.Models;

namespace shopapp.webui.Data
{
    public static class ProductRepository
    {
        private static List<Product> _products = null;
        static ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product {ProductId = 1, Name = "Iphone 8",  Price = 3000, Description="Harika", ImageUrl = "1.jpg"},
                new Product {ProductId = 2, Name = "Iphone 9",  Price = 3000, Description="Harika", ImageUrl = "1.jpg"},
                new Product {ProductId = 3, Name = "Iphone 10",  Price = 3000, Description="Harika", ImageUrl = "1.jpg"},
                new Product {ProductId = 4, Name = "Iphone 11",  Price = 3000, Description="Harika", ImageUrl = "1.jpg"},
            };
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static void AddProduct(Product product)
        {
            _products.Add(product);

        }

        public static Product GetProductById(int productId)
        {
            return _products.FirstOrDefault(p => p.ProductId == productId);
        }

    }
}