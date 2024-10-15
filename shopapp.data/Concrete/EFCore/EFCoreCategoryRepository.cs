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
        
    }
}