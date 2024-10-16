using shopapp.data.Abstract;
using shopapp.data.Concrete.EFCore;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class ProductManager : IProductService
    {
        // EFCoreProductRepository productRepository = new();
        // Normalde ustteki gibi kullanabiliriz ancak eger boyle kullanirsak ilerde EFCore yerine MYSQL ile calistigimizda sorun olacaktir ya da dapper'a gectigimizde
        // Oysa biz IProductRepository ile sanal olarak ornegin create dersek artik arkada ne cagiriyorsa bizi ilgilendirmeyecegi icin direkt Dapper'a da gecsek bir sorun olmayacaktir.
        // Bunu yapalim
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            // Ilk olarak yukarida olusturduk private olarak icini bos yaptik
            // Program calistiginda otomatik olarak buraya inject edilecek EFCoreProductRepository

        }

        // Bunlari yaptik okey ancak proje calistirildiginda IProductRepository ile birlikte ProductManager'in de gonderilmesi gerekir ve cagrilmasi gerekir.
        // Bunun icin Startup.cs'e ya da Program.cs'e

        // var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // builder.Services.AddScoped<IProductRepository, EFCoreProductRepository>();
        //  IProductRepository cagirildiginda EFCoreProductRepository gondermek istedigimizi soyledik.
        // !!!! Alttakini de simdi ekledik
        // builder.Services.AddScoped<IProductService, ProductManager>();
        // builder.Services.AddControllersWithViews();

        // var app = builder.Build();
        public void Create(Product entity)
        {
            // Is kurallarini uygula eger sorun yoksa alttakini calistir
            // Mesela create'e gelen entity dogru mu, sorun var mi vesaire
            _productRepository.Create(entity);
        }

        public void Detele(Product entity)
        {
            // Is Kurallari
            // ...
            _productRepository.Detele(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}