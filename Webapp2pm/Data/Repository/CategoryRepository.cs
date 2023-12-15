using Webapp2pm.Data.Repository.IRepository;
using Webapp2pm.Models;

namespace Webapp2pm.Data.Repository
{
    public class CategoryRepository: Repository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Category categoryObj)
        {
            _db.Categories.Update(categoryObj);
        }
    }
}
