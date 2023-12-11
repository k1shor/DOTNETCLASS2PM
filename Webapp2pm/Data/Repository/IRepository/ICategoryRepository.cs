using Webapp2pm.Models;

namespace Webapp2pm.Data.Repository.IRepository
{
    public interface ICategoryRepository :IRepository<Category>
    {
        void Update(Category categoryObj);

    }
}
