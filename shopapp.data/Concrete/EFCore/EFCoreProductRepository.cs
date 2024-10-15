using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EFCore
{
    public class EFCoreProductRepository : EFCoreGenericRepository<Product, ShopContext>, IProductRepository
    // Biz artik instance almis olduk.
    // TEntity olarak product'i yolladik, context olarak shopcontext'i yolladik
    // Ayrica eger product'a ozel metod varsa onu da getirsin diye IProductRepository'i de cagirdik cunku mesela ekstra getPopularProducts diye bir sey gelebilir.
    {
        public List<Product> GetPopularProducts()
        {
            return new();
        }
    }
}