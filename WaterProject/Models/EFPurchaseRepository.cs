using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        // declare a private BookstoreContext variable
        private BookstoreContext context;
        
        // create a constructor that takes a BookstoreContext object
        public EFPurchaseRepository (BookstoreContext temp)
        {
            // set the private context variable to the passed-in object
            context = temp;
        }
        
        // define a property for the Purchases object, which includes the Lines and Books objects
        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Books);
        
        // define a method to save a Purchase object
        public void SavePurchase(Purchase purchase)
        {
            // attach the Books object to the context
            context.AttachRange(purchase.Lines.Select(x => x.Books));
            
            // if the PurchaseId is 0, add the purchase to the context
            if (purchase.PurchaseId == 0)
            {
                context.Purchases.Add(purchase);
            }
            
            // save changes to the context
            context.SaveChanges();
        }
    }
}

