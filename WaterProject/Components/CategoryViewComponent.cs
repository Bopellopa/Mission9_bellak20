using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;

//used to pull from our repository and add categories to page
namespace WaterProject.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }
        public CategoryViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }

        //routes to correct category page when selected
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory =
                RouteData?.Values["category"];
            var category = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(category);

        }

 
    }
}
