namespace receipt_app.models;

public class Receipt
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public DateTime IssuedAt { get; set; }
    public ICollection<ReceiptItem> ReceiptItems { get; set; } = new List<ReceiptItem>();
}
