using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public interface IProductService
    {
        Product GetById(int id);

        List<Product> GetAll();

        void Create(Product entity);

        void Update(Product entity);

        void Detele(Product entity);
    }
}