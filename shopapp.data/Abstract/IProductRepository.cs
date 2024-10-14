using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        // Otomatik olarak buraya generik olarak gelmis olacak zaten.
        // Biz generic'ten haric sadece product'a ozel olanlari da buraya ekleyebiliriz.

        List<Product> GetPopularProducts();
    }
}