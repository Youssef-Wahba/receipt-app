namespace receipt_app.Dtos.Items;

public record class ItemDto(
    int Id,
    string Name,
    decimal Price,
    int Balance
);
