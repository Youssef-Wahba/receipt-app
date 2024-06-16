using System.ComponentModel.DataAnnotations;

namespace receipt_app;

public record class CompleteReceiptDto(
    [Required]
    decimal PaidAmount = 0
);
