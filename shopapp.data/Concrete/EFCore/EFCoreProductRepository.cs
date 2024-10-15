using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EFCore
{
    public class EFCoreProductRepository : IProductRepository
    {
        private readonly ShopContext _context;

        public EFCoreProductRepository(ShopContext context)
        {
            _context = context;
        }

        public void Create(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Detele(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetPopular5Products()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetPopularProducts()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}