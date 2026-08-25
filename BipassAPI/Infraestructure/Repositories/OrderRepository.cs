using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BipassDbContext _dbContext;

        public OrderRepository(BipassDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddOrder(Order newOrder)
        {
            _dbContext.Orders.Add(newOrder);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Order>> GetOrdersByUser(int userId)
        {
            return await _dbContext.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderItems) // Incluimos los ítems de la orden
                .ThenInclude(oi => oi.TicketType) // Y el tipo de ticket de cada ítem
                .ToListAsync();
        }
        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _dbContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.TicketType)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task UpdateOrderStatus(int orderId, string status)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = status;
                _dbContext.Orders.Update(order);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
