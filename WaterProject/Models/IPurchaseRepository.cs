using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace WaterProject.Models 
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchase> Purchases { get; } // Declaring a property called "Purchases" of type IQueryable<Purchase>
        public void SavePurchase(Purchase purchase); // Declaring a method called "SavePurchase" that takes a parameter of type Purchase and returns void
    }
}

