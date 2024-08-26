using BasarsoftFirst.data;
using BasarsoftFirst.Service;
using System.Collections.Generic;
using System.Linq;
using BasarsoftFirst.UnitOfWork;

namespace BasarsoftFirst.Service
{
    public class ItemDbService : IItemManager<BasarsoftFirst.congrate.Item> 
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemDbService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<BasarsoftFirst.congrate.Item> GetItemList()
        {
            return _unitOfWork.Repository.GetItemList().ToList(); 
        }

        public BasarsoftFirst.congrate.Item GetById(int id)
        {
            return _unitOfWork.Repository.GetById(id); 
        }

        public void Add(BasarsoftFirst.congrate.Item entity)
        {
            _unitOfWork.Repository.Add(entity); 
            _unitOfWork.Complete(); 
        }

        public void Update(BasarsoftFirst.congrate.Item entity)
        {
            _unitOfWork.Repository.Update(entity); 
            _unitOfWork.Complete(); 
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository.Delete(id); 
            _unitOfWork.Complete(); 
        }
    }
}
