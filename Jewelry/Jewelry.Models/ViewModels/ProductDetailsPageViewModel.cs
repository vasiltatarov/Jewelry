namespace Jewelry.Models.ViewModels;

using Jewelry.Models.DbModels;
using Jewelry.Models.Enumerations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

public class ProductDetailsPageViewModel : ViewModel
{
    [ValidateNever]
    public Product Product { get; set; }

    [Range(1, 100, ErrorMessage = "Please enter a value between 1 and 100")]
    public int Count { get; set; }

    [ValidateNever]
    public double Price { get; set; }

    [ValidateNever]
    public Availability Availability { get; set; }
}
