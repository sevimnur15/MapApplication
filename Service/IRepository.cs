namespace BasarsoftFirst.Service
{
    public interface IRepository<T> where T : class
    {
        
            IEnumerable<T> GetItemList();
            T GetById(int id);
            void Add(T entity);
            void Update(T entity);
            void Delete(int id);
        
    }


}

