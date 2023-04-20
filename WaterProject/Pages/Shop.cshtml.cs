using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterProject.infrastructure;
using WaterProject.Models;

namespace WaterProject.Pages
{
    // This is the Shop page model class. It is a PageModel class that inherits from the Razor Pages framework. 
    public class ShopModel : PageModel
    {
        // Here we declare a private property of the IBookstoreRepository interface.
        // We will use it in the constructor injection to get access to the repository.
        private IBookstoreRepository repo { get; set; }

        // Here we define the constructor of the ShopModel class that receives an instance of the IBookstoreRepository interface.
        // We use this constructor to set the value of the private repo property.
        public ShopModel(IBookstoreRepository temp)
        {
            repo = temp;
        }

        // Here we define two public properties that we will use in the Razor view.
        // One for the Basket and one for the ReturnUrl.
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        // This is the handler for the HTTP GET request for the Shop page.
        public void OnGet(string returnUrl)
        {
            // Here we set the value of the ReturnUrl property to the returnUrl parameter if it is not null. Otherwise, it is set to "/".
            ReturnUrl = returnUrl ?? "/";
        }

        // This is the handler for the HTTP POST request for the Shop page.
        // It receives the BookId parameter and the returnUrl string.
        public IActionResult OnPost(int BookId, string returnUrl)
        {
            // We get the book with the given BookId from the repository.
            Books b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            // We add the book to the basket.
            basket.AddItem(b, 1);

            // We redirect the user to the page specified in the returnUrl parameter.
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
