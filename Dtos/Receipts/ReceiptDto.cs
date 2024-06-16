namespace receipt_app;

public record class ReceiptDto(
    int Id,
    decimal TotalAmount,
    decimal PaidAmount,
    decimal RemainingAmount,
    DateTime IssuedAt,
    IEnumerable<ReceiptItemDto> ReceiptItems
);