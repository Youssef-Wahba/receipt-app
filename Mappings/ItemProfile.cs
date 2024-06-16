using AutoMapper;
using receipt_app.Dtos.Items;
using receipt_app.models;

namespace receipt_app.Mappings;

public class ItemProfile: Profile{
    public ItemProfile(){
        CreateMap<Item, ItemDto>();
        CreateMap<CreateItemDto, Item>();
        CreateMap<ItemDto, Item>(); 
    }
}
