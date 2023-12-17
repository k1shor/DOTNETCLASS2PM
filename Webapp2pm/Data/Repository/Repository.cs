﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Webapp2pm.Data.Repository.IRepository;
using Webapp2pm.Models;

namespace Webapp2pm.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDbContext _db;
        DbSet<T> _dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if(includeProperties != null)
            {
                query = query.Include(includeProperties);
            }
            return query;
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expr, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (expr != null)
            {
                query = query.Where(expr);
            }
            if (includeProperties != null)
            {
                query = query.Include(includeProperties);
            }
            return query.FirstOrDefault();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
