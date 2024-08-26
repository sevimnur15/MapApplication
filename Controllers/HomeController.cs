using BasarsoftFirst.congrate;
using BasarsoftFirst.Home;
using BasarsoftFirst.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BasarsoftFirst.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IItemManager<Item> _itemManager;

        public HomeController(IItemManager<Item> itemManager)
        {
            _itemManager = itemManager;
        }

        // Tüm öğeleri döndürür
        [HttpGet]
        public Response GetItemList()
        {
            var _result = new Response();
            try
            {
                _result.Data = _itemManager.GetItemList();
                _result.Success = true;
                return _result;
            }
            catch (System.Exception _ex)
            {
                _result.Message = _ex.Message;
                return _result;
            }
        }

        // Belirli bir öğeyi ID ile döndürür
        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            var _result = new Response();
            try
            {
                var item = _itemManager.GetById(id);
                if (item != null)
                {
                    _result.Data = item;
                    _result.Success = true;
                }
                else
                {
                    _result.Message = "Item bulunamadı.";
                }
                return _result;
            }
            catch (System.Exception _ex)
            {
                _result.Message = _ex.Message;
                return _result;
            }
        }

        // Yeni bir öğe ekler
        [HttpPost]
        public Response Add(Item entity)
        {
            var _result = new Response();
            try
            {
                _itemManager.Add(entity);
                _result.Success = true;
                _result.Message = "Item eklendi.";
                return _result;
            }
            catch (System.Exception _ex)
            {
                _result.Message = _ex.Message;
                return _result;
            }
        }

        // Mevcut bir öğeyi günceller
        [HttpPut]
        public Response Update(Item entity)
        {
            var _result = new Response();
            try
            {
                _itemManager.Update(entity);
                _result.Success = true;
                _result.Message = "Item başarıyla güncellendi.";
                return _result;
            }
            catch (System.Exception _ex)
            {
                _result.Message = _ex.Message;
                return _result;
            }
        }

        // Belirli bir öğeyi ID ile siler
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            var _result = new Response();
            try
            {
                _itemManager.Delete(id);
                _result.Success = true;
                _result.Message = "Item başarıyla silindi.";
                return _result;
            }
            catch (System.Exception _ex)
            {
                _result.Message = _ex.Message;
                return _result;
            }
        }
    }
}
