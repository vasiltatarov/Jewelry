namespace Jewelry.Models.DbModels;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    public string Area { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string StreetAddress { get; set; }

    [NotMapped]
    public string Role { get; set; }
}
