namespace Jewelry.Models.DbModels;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class OrderHeader
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }

    [ValidateNever]
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime ShippingDate { get; set; }

    public double OrderTotal { get; set; }

    public string OrderStatus { get; set; }

    public string PaymentStatus { get; set; }

    public string TrackingNumber { get; set; }

    public string Carrier { get; set; }

    public DateTime PaymentDate { get; set; }

    public string SessionId { get; set; }

    public string PaymentIntentId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    public string Area { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Street { get; set; }

    [Required]
    public string StreetAddress { get; set; }

    [Required]
    public string PhoneNumber { get; set; }
}