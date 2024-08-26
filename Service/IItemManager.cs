using BasarsoftFirst.data;
using BasarsoftFirst.Home;
using BasarsoftFirst.congrate;
using BasarsoftFirst.Service;
using System.Collections.Generic;

namespace BasarsoftFirst.Service
{
    public interface IItemManager<Item> where Item : class
    {
        
        List<Item> GetItemList();
        Item GetById(int id);
        void Add(Item entity);
        void  Update(Item entity);
        void Delete(int id);
    }
}

