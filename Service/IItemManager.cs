using BasarsoftFirst.data;
using BasarsoftFirst.Home;
using BasarsoftFirst.congrate;
using BasarsoftFirst.Service;

namespace BasarsoftFirst.Service
{
    public interface IItemManager<T> where T : class
    {
        Response GetAll();
        Response GetById(int id);
        Response Add(T entity);
        Response Update(T entity);
        Response Delete(int id);
    }
}

