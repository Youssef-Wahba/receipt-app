using AutoMapper;
using receipt_app.Dtos.Items;
using receipt_app.models;

namespace receipt_app.Service;

public class ItemService(AppDbContext appDbContext, IMapper mapper)
{
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly IMapper _mapper = mapper;

    public ItemDto? AddItem(CreateItemDto newItem){
        bool itemExists = _appDbContext.Items.Any(i => i.Name == newItem.Name);
        if(!itemExists)
        {
            Item item = _mapper.Map<Item>(newItem);
            _appDbContext.Items.Add(item);
            _appDbContext.SaveChanges();
            return _mapper.Map<ItemDto>(item);
        }else return null;
    }

    public IEnumerable<ItemDto> GetItems(){
        return _appDbContext.Items.Select(i => _mapper.Map<ItemDto>(i));
    }

    public ItemDto? GetItem(int id){
        Item? item = _appDbContext.Items.Find(id);
        if(item == null) return null;
        return _mapper.Map<ItemDto>(item);
    }

    public bool DeleteItem(int id){
        Item? item = _appDbContext.Items.Find(id);
        if(item == null) return false;
        _appDbContext.Items.Remove(item);
        _appDbContext.SaveChanges();
        return true;
    }
}
