using BasarsoftFirst.congrate;
using BasarsoftFirst.Home;
using BasarsoftFirst.Service;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet]
        public Response GetAll()
        {
            return _itemManager.GetAll();
        }

        [HttpGet("{id}")]
        public Response GetById(int id)
        {
            return _itemManager.GetById(id);
        }

        [HttpPost]
        public Response Add(Item entity)
        {
            return _itemManager.Add(entity);
        }

        [HttpPut]
        public Response Update(Item entity)
        {
            return _itemManager.Update(entity);
        }

        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            return _itemManager.Delete(id);
        }


    }
}
