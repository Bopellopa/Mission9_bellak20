using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class Basket
    {
        // List to hold the items in the shopping basket
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        // Method to add an item to the basket
        public virtual void AddItem(Books book, int qty)
        {
            // Get the basket line item for the specified book
            BasketLineItem line = Items
                .Where(b => b.Books.BookId == book.BookId)
                .FirstOrDefault();

            // If the book is not already in the basket, add it as a new line item
            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = book,
                    Quantity = qty,
                });
            }
            // If the book is already in the basket, update the quantity
            else
            {
                line.Quantity += qty;
            }
        }

        // Method to remove an item from the basket
        public virtual void RemoveItem(Books book)
        {
            Items.RemoveAll(x => x.Books.BookId == book.BookId);
        }

        // Method to clear the basket (i.e. remove all items)
        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        // Method to calculate the total cost of all items in the basket
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Books.Price);
            return sum;
        }
    }

    // Class to represent a line item in the shopping basket
    public class BasketLineItem
    {
        [Key]
        public int LineId { get; set; } //an id for each line
        public Books Books { get; set; } // The book being purchased
        public Books Price { get; set; } // The price of the book (not used in the current implementation)
        public int Quantity { get; set; } // The quantity of the book being purchased
        public int Subtotal { get; set; } // The subtotal for this line item (not used in the current implementation)
    }

}
