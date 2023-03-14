using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models.ViewModels
{
    public class PageInfo
    {
        //calc num of books to calc num of pages
        public int TotalNumProjects { get; set; }
        public int ProjectsPerPage {get;set;}
        public int CurrentPage { get; set; }

        //how many pages are needed
        public int TotalPages => (int) Math.Ceiling((double) TotalNumProjects / ProjectsPerPage);
    }
}
