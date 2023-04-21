using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class Purchase
    {
        [Key] // Indicates that the PurchaseId property is the primary key
        [BindNever] // Indicates that this property should not be bound to in model binding
        public int PurchaseId { get; set; }

        [BindNever] // Indicates that this property should not be bound to in model binding
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please Enter a name:")] // Indicates that this property is required and sets the error message if it is not provided
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")] // Indicates that this property is required and sets the error message if it is not provided
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; } // Optional second address line
        public string AddressLine3 { get; set; } // Optional third address line

        [Required(ErrorMessage = "Please enter the city")] // Indicates that this property is required and sets the error message if it is not provided
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the State")] // Indicates that this property is required and sets the error message if it is not provided
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter the Zip code")] // Indicates that this property is required and sets the error message if it is not provided
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter the country")] // Indicates that this property is required and sets the error message if it is not provided
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your email")] // Indicates that this property is required and sets the error message if it is not provided
        public string Email { get; set; }
    }
}
