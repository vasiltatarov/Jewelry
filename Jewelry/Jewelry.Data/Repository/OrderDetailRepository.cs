namespace Jewelry.Data.Repository;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Models.DbModels;

public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
    private readonly ApplicationDbContext dbContext;

    public OrderDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Update(OrderDetail entity)
    {
        this.dbContext.OrderDetails.Update(entity);
    }
}