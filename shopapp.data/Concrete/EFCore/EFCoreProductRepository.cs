using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EFCore
{
    public class EFCoreProductRepository : IProductRepository
    {
        private ShopContext db = new ShopContext();

        public void Create(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
        }


    }
}