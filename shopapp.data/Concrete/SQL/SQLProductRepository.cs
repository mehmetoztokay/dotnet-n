using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.SQL
{
    public class SQLProductRepository : IProductRepository
    {
        Product GetById(int id);
        List<Product> GetAll();
        void Create(Product entity);
        void Update(Product entity);
        void Detele(int id);

    }
}