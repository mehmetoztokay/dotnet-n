using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;

namespace shopapp.data.Concrete.EFCore;

public class EFCoreGenericRepository<TEntity, TContext> : IRepository<TEntity>
    // TEntity dedigimiz: ProductRepository, CategoryRepository ya da baska olusturursak onlar yani
    // TContext de aslinda olusturdugumuz DBContext'i yollayacagiz.
    where TEntity : class
    where TContext : DbContext, new()
    // TEntity class olacak demis olduk, TContext de DBContext'ten olacak dedik
    // new() diyerek de instance olusturulabilir dedik.
{
    public void Create(TEntity entity)
    {
        using (var _context = new TContext())
        {
            _context.Set<TEntity>().Add(entity);
            // Burada dedik ki TEntity eger product ya da baska bir sey ise ona ekle.
            // Product mi artik category mi belli degil, instance oldugunda belli olacak o.
            _context.SaveChanges();
        }
    }

    public void Detele(TEntity entity)
    {
        using (var _context = new TContext())
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }

    public List<TEntity> GetAll()
    {
        using (var _context = new TContext())
        {
            return _context.Set<TEntity>().ToList();
        }
    }

    public TEntity GetById(int id)
    {
        using (var _context = new TContext())
        {
            return _context.Set<TEntity>().Find(id);
        }
    }

    public void Update(TEntity entity)
    {
        using (var _context = new TContext())
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
