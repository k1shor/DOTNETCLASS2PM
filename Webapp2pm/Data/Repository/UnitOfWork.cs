﻿using Webapp2pm.Data.Repository.IRepository;

namespace Webapp2pm.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; set; }
        public IProductRepository Product { get; set; }

        public UnitOfWork(ApplicationDbContext db, ICategoryRepository _category, IProductRepository _product)
        {
            _db = db;
            Category = _category;
            Product = _product;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
