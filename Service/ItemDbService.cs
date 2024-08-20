using BasarsoftFirst.congrate;
using BasarsoftFirst.data;
using BasarsoftFirst.Home;
using BasarsoftFirst.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BasarsoftFirst.Service
{
    public class ItemDbService<T> : IItemManager<T> where T : class
    {
        private readonly ItemDb _context;
        private readonly DbSet<T> _dbSet;

        public ItemDbService(ItemDb context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Tüm verileri getirir
        public List<T> GetAll()
        {
            try
            {
                return _dbSet.ToList(); // Tüm verileri döndürür
            }
            catch
            {
                return new List<T>(); // Hata durumunda boş bir liste döner
            }
        }

        // ID'ye göre bir veri getirir
        public List<T> GetById(int id)
        {
            try
            {
                var item = _dbSet.Find(id);
                if (item == null)
                {
                    return new List<T>(); // Veri bulunamadığında boş liste döner
                }
                return new List<T> { item }; // Bulunan öğeyi içeren liste döner
            }
            catch
            {
                return new List<T>(); // Hata durumunda boş bir liste döner
            }
        }

        // Yeni bir veri ekler
        public List<T> Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                return _dbSet.ToList(); // Güncellenmiş listeyi döndürür
            }
            catch
            {
                return new List<T>(); // Hata durumunda boş bir liste döner
            }
        }

        // Mevcut bir veriyi günceller
        public List<T> Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                _context.SaveChanges();
                return _dbSet.ToList(); // Güncellenmiş listeyi döndürür
            }
            catch
            {
                return new List<T>(); // Hata durumunda boş bir liste döner
            }
        }

        // ID'ye göre bir veriyi siler
        public List<T> Delete(int id)
        {
            try
            {
                var item = _dbSet.Find(id);
                if (item == null)
                {
                    return new List<T>(); // Veri bulunamadığında boş liste döner
                }

                _dbSet.Remove(item);
                _context.SaveChanges();
                return _dbSet.ToList(); // Güncellenmiş listeyi döndürür
            }
            catch
            {
                return new List<T>(); // Hata durumunda boş bir liste döner
            }
        }
    }
}
