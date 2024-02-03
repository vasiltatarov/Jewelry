namespace Jewelry.Models.DbModels;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public double Price { get; set; }

    [Range(1, 1000)]
    public int Quantity { get; set; }

    public bool OutOfStock { get; set; }

    public int CategoryId { get; set; }

    [ValidateNever]
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    [ValidateNever]
    public List<ProductImage> ProductImages { get; set; }
}
