using BasarsoftFirst.congrate;
using BasarsoftFirst.data;
using BasarsoftFirst.Home;
using BasarsoftFirst.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasarsoftFirst.Service
{
   
        
        public class ItemDbService<T> : IItemManager<T> where T : class
        {
            private  readonly ItemDb _context;
            private readonly DbSet<T> _dbSet;

            public ItemDbService(ItemDb context)
            {
                _context = context;
                _dbSet = _context.Set<T>();
            }

            public Response GetAll()
            {
                try
                {
                    var items = _dbSet.ToList();
                    return new Response { Value = items, Result = true, Message = "Veriler getirildi." };
                }
                catch (Exception ex)
                {
                    return new Response { Value = null, Result = false, Message = ex.Message };
                }
            }

            public Response GetById(int id)
            {
                try
                {
                    var item = _dbSet.Find(id);
                    if (item == null)
                    {
                        return new Response { Value = null, Result = false, Message = "Veri bulunamadı" };
                    }
                    return new Response { Value = item, Result = true, Message = "Veri bulundu" };
                }
                catch (Exception ex)
                {
                    return new Response { Value = null, Result = false, Message = ex.Message };
                }
            }

            public Response Add(T entity)
            {
                try
                {
                    _dbSet.Add(entity);
                    _context.SaveChanges();
                    return new Response { Value = entity, Result = true, Message = "Veri başarıyla eklendi" };
                }
                catch (Exception ex)
                {
                    return new Response { Value = null, Result = false, Message = ex.Message };
                }
            }

            public Response Update(T entity)
            {
                try
                {
                    _dbSet.Update(entity);
                    _context.SaveChanges();
                    return new Response { Value = entity, Result = true, Message = "Veri başarıyla güncellendi" };
                }
                catch (Exception ex)
                {
                    return new Response { Value = null, Result = false, Message = ex.Message };
                }
            }

            public Response Delete(int id)
            {
                try
                {
                    var item = _dbSet.Find(id);
                    if (item == null)
                    {
                        return new Response { Value = null, Result = false, Message = "Veri bulunamadı" };
                    }

                    _dbSet.Remove(item);
                    _context.SaveChanges();
                    return new Response { Value = item, Result = true, Message = "Veri başarıyla sillindi" };
                }
                catch (Exception ex)
                {
                    return new Response { Value = null, Result = false, Message = ex.Message };
                }
            }
        }
    

}