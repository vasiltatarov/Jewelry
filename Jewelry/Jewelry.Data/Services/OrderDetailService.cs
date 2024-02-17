namespace Jewelry.Data.Services;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Data.Services.IServices;
using Jewelry.Models.DbModels;

public class OrderDetailService : IOrderDetailService
{
    private readonly IOrderDetailRepository orderDetailRepository;

    public OrderDetailService(IOrderDetailRepository orderDetailRepository)
    {
        this.orderDetailRepository = orderDetailRepository;
    }
    public void Add(OrderDetail orderDetail)
    {
        this.orderDetailRepository.Add(orderDetail);
        this.orderDetailRepository.Save();
    }
}
