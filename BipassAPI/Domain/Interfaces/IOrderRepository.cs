using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {
        // Crea una nueva orden de compra.
        public Task AddOrder(Order newOrder);

        // Obtiene todas las órdenes de un usuario específico.
        public Task<List<Order>> GetOrdersByUser(int userId);

        // Obtiene una orden por su ID, incluyendo los ítems de la orden.
        public Task<Order?> GetOrderById(int orderId);

        // Actualiza el estado de una orden.
        public Task UpdateOrderStatus(int orderId, string status);
    }
}
