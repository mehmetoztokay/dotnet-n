using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface IProductRepository
    {
        Product GetById(int id);
        List<Product> GetAll();
        void Create(Product entity);
        void Update(Product entity);
        void Detele(int id);

    }
}