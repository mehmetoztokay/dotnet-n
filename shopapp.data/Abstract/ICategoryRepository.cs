using shopapp.entity;
using shopapp.data.Abstract;

namespace shopapp.data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Categort> GetPopularCategories();

    }
}