using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;
using WaterProject.Models.ViewModels;

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {

        private IBookstoreRepository repo;

        // Constructor injection of the IBookstoreRepository dependency
        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        // Action method to display books with pagination and filtering by category
        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            // Create a BooksViewModel instance with filtered and paginated books data
            var x = new BooksViewModel
            {
                Books = repo.Books
                // Filter books by category if specified, otherwise include all categories
                .Where(b => b.Category == category || category == null)
                // Order books by book ID
                .OrderBy(b => b.BookId)
                // Skip books that appear before the start of the current page
                .Skip((pageNum - 1) * pageSize)
                // Take only the books that appear on the current page
                .Take(pageSize),
                // Create a PageInfo instance to store pagination information
                PageInfo = new PageInfo
                {
                    // Set the total number of books based on the category filter (if any)
                    TotalNumProjects = (category == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == category).Count()),
                    // Set the number of books per page
                    ProjectsPerPage = pageSize,
                    // Set the current page number
                    CurrentPage = pageNum
                }
            };

            // Return the view with the BooksViewModel instance as the model
            return View(x);
        }
    }
}
