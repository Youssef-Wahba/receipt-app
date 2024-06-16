using System.ComponentModel.DataAnnotations;

namespace receipt_app.Dtos.Items;

public record class ItemBalanceDto(
    [Required]
    [Range(1,int.MaxValue,ErrorMessage ="id must be greater than 1")]
    int ItemId,
    [Required]
    [Range(1,int.MaxValue,ErrorMessage ="balance must be greater than 1")]
    int Balance
);
