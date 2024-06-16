using System.ComponentModel.DataAnnotations;

namespace receipt_app.Dtos.Items;

public record class CreateItemDto(
    [Required]
    [StringLength(50,ErrorMessage ="max length is 50")]
    string Name,
    [Required]
    [Range(0,double.MaxValue, ErrorMessage ="price not negative")]
    decimal Price,
    [Required]
    [Range(0,int.MaxValue, ErrorMessage ="balance not negative")]
    int Balance
);
