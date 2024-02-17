namespace Jewelry.Data.Repository.IRepository;

using Jewelry.Models.DbModels;

public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    void Update(ApplicationUser entity);
}