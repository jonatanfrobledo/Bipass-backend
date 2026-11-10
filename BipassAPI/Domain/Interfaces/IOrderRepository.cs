using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder(Order newOrder);

        Task<List<Order>> GetOrdersByUser(int userId);

        Task<List<Order>> GetOrdersByUserIdAsync(int userId);

        Task<Order?> GetOrderById(int orderId);

        Task<Order?> GetOrderByIdAsync(int orderId);

        Task UpdateOrderStatus(int orderId, string status);

        Task UpdateOrder(Order order);
    }
}