using BasarsoftFirst.data;
using BasarsoftFirst.Home;
using BasarsoftFirst.congrate;
using BasarsoftFirst.Service;
using System.Collections.Generic;

namespace BasarsoftFirst.Service
{
    public interface IItemManager<T> where T : class
    {
        
        List<T> GetAll();
        List<T> GetById(int id);
        List<T> Add(T entity);
        List<T> Update(T entity);
        // Belirli bir id'ye göre öğe siler ve list1 adında bir Response listesi döner
        List<T> Delete(int id);
    }
}

