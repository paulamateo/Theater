using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Theater.Models;

namespace Theater.Data {
    
    public class PurchaseRepository : IPurchaseRepository {
        private readonly TheaterContext _context;

        public PurchaseRepository(TheaterContext context) {
            _context = context;
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public List<Purchase> GetAllPurchases() {
            return _context.Purchases.ToList();
        }

        public Purchase? GetPurchase(int purchaseId) {
            return _context.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
        }

        public void AddPurchase(Purchase purchase) {
            _context.Purchases.Add(purchase);
            SaveChanges();
        }

    }
}