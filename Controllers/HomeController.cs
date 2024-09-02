using BasarsoftFirst.congrate;
using BasarsoftFirst.Home;
using BasarsoftFirst.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BasarsoftFirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IRepository<WktModels> _itemManager;

        public HomeController(IRepository<WktModels> itemManager)
        {
            _itemManager = itemManager;
        }

        // Tüm WKT'leri döndürür
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

        // Belirli bir WKT'yi ID ile döndürür
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
                    _result.Message = "WKT bulunamadı.";
                }
                return _result;
            }
            catch (System.Exception _ex)
            {
                _result.Message = _ex.Message;
                return _result;
            }
        }

        // Yeni bir WKT ekler
        [HttpPost("addWKT")]
        public Response AddWKT(WktModels entity)
        {
            var _result = new Response();
            try
            {
                var item = new WktModels { Wkt = entity.Wkt, Name = entity.Name };
                _itemManager.Add(item); // WKT nesnesini ekle
                _result.Success = true;
                _result.Message = "WKT başarıyla eklendi.";
                return _result;
            }
            catch (System.Exception _ex)
            {
                _result.Message = _ex.Message;
                return _result;
            }
        }

        // Mevcut bir WKT'yi günceller
        [HttpPut]
        public Response Update(WktModels entity)
        {
            var _result = new Response();
            try
            {
                _itemManager.Update(entity); // WKT nesnesini güncelle
                _result.Success = true;
                _result.Message = "WKT başarıyla güncellendi.";
                return _result;
            }
            catch (System.Exception _ex)
            {
                _result.Message = _ex.Message;
                return _result;
            }
        }

        // Belirli bir WKT'yi ID ile siler
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            var _result = new Response();
            try
            {
                _itemManager.Delete(id); // WKT'yi sil
                _result.Success = true;
                _result.Message = "WKT başarıyla silindi.";
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
