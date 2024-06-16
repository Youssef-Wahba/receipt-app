
using Microsoft.EntityFrameworkCore;
using receipt_app.models;

namespace receipt_app.Service;

public class ReceiptService(AppDbContext appDbContext)
{
    AppDbContext _appDbContext = appDbContext;
    
    public Receipt CreateReceipt()
    {
        var receipt = new Receipt
        {
            TotalAmount = 0,
            PaidAmount = 0,
            RemainingAmount = 0,
            IssuedAt = DateTime.Now,
            ReceiptItems = []
        };
        _appDbContext.Receipts.Add(receipt);
        _appDbContext.SaveChanges();
        return receipt;
    }
    
    // public int AddItemToReceipt(int receiptId, int itemId, int quantity)
    // {
    //     // check receipt found 
    //     Receipt receipt = _appDbContext.Receipts.Find(receiptId);
    //     if(receipt == null) return 0;
    //     // check item found 
    //     Item item = _appDbContext.Items.Find(itemId);
    //     if(item == null) return 1;
    //     if (item.Balance < quantity)
    //         return 2;

    //     ReceiptItem receiptItem = new()
    //     {
    //         ReceiptId = receiptId,
    //         ItemId = itemId,
    //         Quantity = quantity,
    //         TotalPrice = item.Price * quantity
    //     };

    //     item.Balance -= quantity;
    //     receipt.TotalAmount += receiptItem.TotalPrice;
    //     receipt.ReceiptItems.Add(receiptItem);

    //     _appDbContext.ReceiptItems.Add(receiptItem);
    //     _appDbContext.SaveChanges();
    //     return 3;
    // }
    public Receipt AddItemToReceipt(int receiptId, int itemId, int quantity)
{
    var item = _appDbContext.Items.Find(itemId);
    if (item == null)
        throw new InvalidOperationException("Item not found.");

    if (item.Balance < quantity)
        throw new InvalidOperationException("Insufficient balance for item.");

    var receipt = _appDbContext.Receipts.Include(r => r.ReceiptItems).FirstOrDefault(r => r.Id == receiptId);
    if (receipt == null)
        throw new InvalidOperationException("Receipt not found.");

    var receiptItem = new ReceiptItem
    {
        ReceiptId = receiptId,
        ItemId = itemId,
        Quantity = quantity,
        TotalPrice = item.Price * quantity
    };

    item.Balance -= quantity;
    receipt.TotalAmount += receiptItem.TotalPrice;
    receipt.ReceiptItems.Add(receiptItem);

    _appDbContext.Items.Update(item);
    _appDbContext.Receipts.Update(receipt);
    _appDbContext.ReceiptItems.Add(receiptItem);
    _appDbContext.SaveChanges();
    return receipt;
}

    public Receipt CompleteReceipt(int receiptId, decimal paidAmount)
    {
        Receipt receipt = _appDbContext.Receipts.Find(receiptId);
        if(receipt == null) return null;
        receipt.PaidAmount = paidAmount;
        receipt.RemainingAmount = receipt.TotalAmount - paidAmount;
        _appDbContext.SaveChanges();
        return receipt;
    }
    public Receipt GetReceiptById(int receiptId)
    {
        return _appDbContext.Receipts
                    .Include(r => r.ReceiptItems)
                    .ThenInclude(ri => ri.Item)
                    .FirstOrDefault(r => r.Id == receiptId);
    }

}
