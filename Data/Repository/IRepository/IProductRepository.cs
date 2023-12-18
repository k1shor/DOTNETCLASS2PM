using Webapp2pm.Models;

namespace Webapp2pm.Data.Repository.IRepository
{
    public interface IProductRepository :IRepository<Product>
    {
        void Update(Product productObj);

    }
}
