using Theater.Models;

namespace Theater.Data {

    public interface IPurchaseRepository {
        List<Purchase> GetAllPurchases();
        Purchase? GetPurchase(int purchaseId);
        void AddPurchase(Purchase purchase);
    }

}