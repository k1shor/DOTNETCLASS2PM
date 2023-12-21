using Models;
using Webapp2pm.Models;

namespace Webapp2pm.Data.Repository.IRepository
{
    public interface IShoppingCartRepository :IRepository<ShoppingCart>
    {
        void Update(ShoppingCart shoppingCart);

    }
}
