using BasarsoftFirst.data;
using BasarsoftFirst.Service;

namespace BasarsoftFirst.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ItemDb _context;
        public IRepository<BasarsoftFirst.congrate.Item> Repository { get; private set; }

        public UnitOfWork(ItemDb context, IRepository<BasarsoftFirst.congrate.Item> repository)
        {
            _context = context;
            Repository = repository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
