using Theater.Models;
using Theater.Business;
using Microsoft.AspNetCore.Mvc;

namespace Theater.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseController : ControllerBase {
    private readonly IPurchaseService _purchaseService;

    public PurchaseController (IPurchaseService purchaseService) {
        _purchaseService = purchaseService;
    }

    [HttpGet()]
    public ActionResult<List<Purchase>> GetAllPurchases() =>
        _purchaseService.GetAllPurchases();
    
    [HttpGet("{purchaseId}")]
    public ActionResult<Purchase> Get(int purchaseId) {
        var purchase = _purchaseService.GetPurchase(purchaseId);

        if(purchase == null)
            return NotFound();

        return purchase;
    }
    
    [HttpPost()]
    public IActionResult Create([FromBody] Purchase purchase) {    
        _purchaseService.AddPurchase(purchase);
        return CreatedAtAction(nameof(Get), new { purchaseId = purchase.PurchaseId }, purchase);
    }

}
