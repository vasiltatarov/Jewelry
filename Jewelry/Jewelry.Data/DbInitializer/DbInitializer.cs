namespace Jewelry.Data.DbInitializer;

using Jewelry.Models.DbModels;
using Jewelry.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class DbInitializer : IDbInitializer
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly ApplicationDbContext dbContext;

    public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.dbContext = dbContext;
    }

    public void Initialize()
    {
        try
        {
            if (this.dbContext.Database.GetPendingMigrations().Count() > 0)
            {
                this.dbContext.Database.Migrate();
            }
        }
        catch (Exception)
        {
        }

        if (!this.roleManager.RoleExistsAsync(GlobalConstants.RoleAdmin).GetAwaiter().GetResult())
        {
            this.roleManager.CreateAsync(new IdentityRole(GlobalConstants.RoleAdmin)).GetAwaiter().GetResult();

            this.userManager.CreateAsync(new ApplicationUser
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                Name = "Admin",
                Surname = "Adminov",
                Area = "Sofia",
                City = "Chakalo",
                Street = "Shipka 40",
                StreetAddress = "test 123 Ave",
                PhoneNumber = "1112223333",
            }, "admin123").GetAwaiter().GetResult();

            var user = this.dbContext.ApplicationUsers.FirstOrDefault(x => x.Email == "admin@gmail.com");
            this.userManager.AddToRoleAsync(user, GlobalConstants.RoleAdmin).GetAwaiter().GetResult();
        }
    }
}
