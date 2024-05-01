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

    public OrderHeader Get(int id)
    {
        return this.orderHeaderRepository.Get(x => x.Id == id, "User");
    }

    public void UpdateStatus(int id, string orderStatus, string paymentStatus = null)
    {
        this.orderHeaderRepository.UpdateStatus(id, orderStatus, paymentStatus);
        this.orderHeaderRepository.Save();
    }

    public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
    {
        this.orderHeaderRepository.UpdateStripePaymentID(id, sessionId, paymentIntentId);
        this.orderHeaderRepository.Save();
    }
}
