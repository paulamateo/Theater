using Theater.Models;

namespace Theater.Business { 
    public interface IPurchaseService {
        List<Purchase> GetAllPurchases();
        Purchase? GetPurchase(int purchaseId);
        void AddPurchase(Purchase purchase);
    }
}