using System.ComponentModel.DataAnnotations;
using receipt_app.Dtos.Items;

namespace receipt_app.Dtos.Receipts;


public record class CreateReceiptDto(
    IEnumerable<ItemBalanceDto> ItemsBalance,
    [Required]
    [Range(0, double.MaxValue, ErrorMessage ="amount must be greater than 0")]
    decimal PaidAmount
);
