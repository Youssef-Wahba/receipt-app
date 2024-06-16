namespace receipt_app.models;

public class ReceiptItem
{
    public int ReceiptId { get; set; }
    public Receipt Receipt { get; set; } = new Receipt();
    public int ItemId { get; set; }
    public Item Item { get; set; } = new Item();
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
