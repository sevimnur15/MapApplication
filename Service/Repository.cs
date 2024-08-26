using BasarsoftFirst.data;
using BasarsoftFirst.Home;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BasarsoftFirst.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ItemDb _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ItemDb context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetItemList()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _dbSet.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}