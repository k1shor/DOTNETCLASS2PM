using Webapp2pm.Data.Repository.IRepository;
using Webapp2pm.Models;

namespace Webapp2pm.Data.Repository
{
    public class ProductRepository: Repository<Product> , IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Product productObj)
        {
            _db.Products.Update(productObj);
        }
    }
}
