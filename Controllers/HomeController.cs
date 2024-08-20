using BasarsoftFirst.congrate;
using BasarsoftFirst.Home;
using BasarsoftFirst.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq; // Linq namespace'ini eklemeyi unutmayın

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
        public ActionResult<List<Item>> GetAll()
        {
            var _result = new List<Item>();
            try
            {
                _result = _itemManager.GetAll();
                return Ok(_result); // 200 OK döner
            }
            catch (System.Exception _ex)
            {
                return StatusCode(500, new Response { Message = _ex.Message, Success = false }); // 500 Internal Server Error döner
            }
        }

        // Belirli bir öğeyi ID ile döndürür
        [HttpGet("{id}")]
        public ActionResult<Item> GetById(int id)
        {
            try
            {
                var item = _itemManager.GetById(id);
                if (item == null)
                {
                    return NotFound(); // 404 Not Found döner
                }
                return Ok(item); // 200 OK döner
            }
            catch (System.Exception _ex)
            {
                return StatusCode(500, new Response { Message = _ex.Message, Success = false }); // 500 Internal Server Error döner
            }
        }

        // Yeni bir öğe ekler
        [HttpPost]
        public ActionResult<Item> Add(Item entity)
        {
            try
            {
                var createdItems = _itemManager.Add(entity); // Bu satırda birden fazla öğe dönebilir
                var createdItem = createdItems.FirstOrDefault(); // İlk öğeyi al

                if (createdItem == null)
                {
                    return BadRequest(new Response { Message = "Item could not be created.", Success = false }); // Başarısız oldu
                }

                return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem); // 201 Created döner
            }
            catch (System.Exception _ex)
            {
                return StatusCode(500, new Response { Message = _ex.Message, Success = false }); // 500 Internal Server Error döner
            }
        }

        // Mevcut bir öğeyi günceller
        [HttpPut]
        public ActionResult<Item> Update(Item entity)
        {
            var _result = new Response();
            try
            {
                var updatedItem = _itemManager.Update(entity);
                return Ok(updatedItem); // 200 OK döner
            }
            catch (System.Exception _ex)
            {
                return StatusCode(500, new Response { Message = _ex.Message, Success = false }); // 500 Internal Server Error döner
            }
        }

        // Belirli bir öğeyi ID ile siler
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _itemManager.Delete(id);
                return NoContent(); // 204 No Content döner
            }
            catch (System.Exception _ex)
            {
                return StatusCode(500, new Response { Message = _ex.Message, Success = false }); // 500 Internal Server Error döner
            }
        }
    }
}
