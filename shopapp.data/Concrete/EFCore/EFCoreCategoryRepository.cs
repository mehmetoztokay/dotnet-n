
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EFCore;

public class EFCoreCategoryRepository : EFCoreGenericRepository<Category, ShopContext>, ICategoryRepository
{
    public List<Category> GetPopularCategories()
    {
        return new();
    }
}