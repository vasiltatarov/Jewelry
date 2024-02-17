namespace Jewelry.Data.Services;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Data.Services.IServices;
using Jewelry.Models.DbModels;

public class OrderHeaderService : IOrderHeaderService
{
    private readonly IOrderHeaderRepository orderHeaderRepository;

    public OrderHeaderService(IOrderHeaderRepository orderHeaderRepository)
    {
        this.orderHeaderRepository = orderHeaderRepository;
    }

    public void Add(OrderHeader orderHeader)
    {
        this.orderHeaderRepository.Add(orderHeader);
        this.orderHeaderRepository.Save();
    }
}
