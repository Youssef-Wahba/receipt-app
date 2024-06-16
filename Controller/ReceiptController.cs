using Microsoft.AspNetCore.Mvc;
using receipt_app.models;
using receipt_app.Service;

namespace receipt_app;

[ApiController]
[Route("api/receipts")]
public class ReceiptController(ReceiptService receiptService): ControllerBase
{
    ReceiptService _receiptService = receiptService;
    [HttpGet("{id}")]
    public IActionResult GetReceipt(int id)
    {
        Receipt receipt = _receiptService.GetReceiptById(id);
        if(receipt == null) return NotFound(new {message = "receipt not found"});
        return Ok(receipt);
    }
    [HttpPost]
    public IActionResult CreateReceipt()
    {
        Receipt receipt = _receiptService.CreateReceipt();
        return CreatedAtAction(nameof(CreateReceipt), new { id = receipt.Id }, receipt);
    }
    [HttpPost("{receiptId}/items/{itemId}")]
    public IActionResult AddItemToReceipt(int receiptId, int itemId,[FromBody] AddItemReceiptDto addItemReceiptDto)
    {
        try
        {
            Receipt receipt = _receiptService.AddItemToReceipt(receiptId, itemId, addItemReceiptDto.Quantity);
            return CreatedAtAction(nameof(AddItemToReceipt), new { id = receipt.Id }, receipt);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new {message = ex.Message});
        }
    }
    [HttpPost("{receiptId}/complete")]
    public IActionResult CompleteReceipt(int receiptId, [FromBody] CompleteReceiptDto completeReceiptDto)
    {
        Receipt receipt = _receiptService.CompleteReceipt(receiptId, completeReceiptDto.PaidAmount);
        if(receipt == null) return NotFound(new {message = "receipt not found"});
        return Ok(receipt);
    }
}
