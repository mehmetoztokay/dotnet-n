using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EFCore
{
    public class EFCoreCategoryRepository : ICategoryRepository
    {
        private ShopContext db = new ShopContext();

        public void Create(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
        }

        public void Detele(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetPopularCategories()
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}