namespace Jewelry.Data.Repository.IRepository;

using Jewelry.Models.DbModels;

public interface IOrderHeaderRepository : IRepository<OrderHeader>
{
    void Update(OrderHeader entity);

    void UpdateStatus(int id, string orderStatus, string paymentStatus = null);

    void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
}