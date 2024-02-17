namespace Jewelry.Data.Repository.IRepository;

using Jewelry.Models.DbModels;

public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    void Update(OrderDetail entity);
}