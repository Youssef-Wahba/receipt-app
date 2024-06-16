namespace receipt_app;

public record class ReceiptItemDto(
    int ItemId,
    string Name,
    decimal Price,
    int Quantity,
    decimal TotalPrice
);