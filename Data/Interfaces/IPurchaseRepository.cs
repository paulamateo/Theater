using Theater.Models;

namespace Theater.Data {

    public interface IPurchaseRepository {
        List<Purchase> GetAllPurchases();
        void AddPurchase(Purchase purchase);
    }

}