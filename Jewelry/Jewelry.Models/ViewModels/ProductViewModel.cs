namespace Jewelry.Models.ViewModels;

using Jewelry.Models.DbModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ProductViewModel
{
    public Product Product { get; set; }

    [ValidateNever]
    public List<SelectListItem> CategoryList { get; set; }
}
