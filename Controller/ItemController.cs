using Microsoft.AspNetCore.Mvc;
using receipt_app.Dtos.Items;
using receipt_app.Service;

namespace receipt_app.Controller;

[ApiController]
[Route("api/items")]
public class ItemController : ControllerBase
{
    private readonly ItemService _itemService;
    public ItemController(ItemService itemService)
    {
        this._itemService = itemService;
    }
    [HttpPost]
    public IActionResult AddItem([FromBody]CreateItemDto createItemDto){
        ItemDto item = _itemService.AddItem(createItemDto);
        if(item != null)
            return CreatedAtAction(nameof(AddItem), new { id = item.Id }, item);
        else return BadRequest(new {message = "item found with same name"});
    }
    
    [HttpGet]
    public IActionResult GetAllItems(){
        return Ok(_itemService.GetItems());
    }
    [HttpGet("{id}")]
    public IActionResult GetAllItems(int id)
    {
        ItemDto? item = _itemService.GetItem(id);
        if(item == null) return NotFound(new {message = "item not found"});
        return Ok(item);
    }
}
