namespace Jewelry.Data.Services.IServices;

using Jewelry.Models.DbModels;

public interface IOrderHeaderService
{
    void Add(OrderHeader orderHeader);

    OrderHeader Get(int id);

    void UpdateStatus(int id, string orderStatus, string paymentStatus = null);

    void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
}
