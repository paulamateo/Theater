using Theater.Models;
using Theater.Data;

namespace Theater.Business {
    
    public class PurchaseService : IPurchaseService {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository) {
            _purchaseRepository = purchaseRepository;
        } 

        public List<Purchase> GetAllPurchases() => _purchaseRepository.GetAllPurchases();
        public void AddPurchase(Purchase purchase) => _purchaseRepository.AddPurchase(purchase);
        public Purchase? GetPurchase(int purchaseId) => _purchaseRepository.GetPurchase(purchaseId);
    }
}
