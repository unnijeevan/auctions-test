using Microsoft.AspNetCore.Mvc;

namespace MockItemService.Controllers
{
    [ApiController]
    [Route("api/items/[controller]")]
    public class ItemController : ControllerBase
    {
    
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MockItems.Get());
        }
    }
}
