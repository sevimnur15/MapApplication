using BasarsoftFirst.congrate;
using BasarsoftFirst.Home; // WktModels sınıfı için
using BasarsoftFirst.UnitOfWork; // IUnitOfWork için
using System.Collections.Generic;
using System.Linq;

namespace BasarsoftFirst.Service
{
    public class WKTService
    {
        private readonly IRepository<WktModels> _repository;

        public WKTService(IRepository<WktModels> repository)
        {
            _repository = repository;
        }

        public List<WktModels> GetItemList()
        {
            // Repository'den veri alır
            return _repository.GetItemList().ToList();
        }

        public WktModels GetById(int id)
        {
            // Belirli bir öğeyi ID ile alır
            return _repository.GetById(id);
        }

        public void Add(WktModels entity)
        {
            // Yeni bir öğe ekler
            _repository.Add(entity);
        }

        public void Update(WktModels entity)
        {
            // Mevcut bir öğeyi günceller
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            // Belirli bir öğeyi ID ile siler
            _repository.Delete(id);
        }
    }
}
