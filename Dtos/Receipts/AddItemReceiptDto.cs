using System.ComponentModel.DataAnnotations;

namespace receipt_app;

public record class AddItemReceiptDto(
    int Quantity = 1
);
