namespace Webapp2pm.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }
        public IShoppingCartRepository ShoppingCart { get; }

        public void Save();
    }
}
