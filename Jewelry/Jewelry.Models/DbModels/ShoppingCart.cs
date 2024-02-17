namespace Jewelry.Models.DbModels;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ShoppingCart
{
    [Key]
    public int Id { get; set; }

    [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
    public int Count { get; set; }

    public int ProductId { get; set; }

    [ValidateNever]
    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [Required]
    public string UserId { get; set; }

    [ValidateNever]
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }
}
