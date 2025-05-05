


using Formationn_Ecommerce.Core.Interfaces.Repositories.Base;
using Formationn_Ecommerce.Entities.Orders;

namespace Formationn_Ecommerce.Core.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<OrderHeader>
    {
        Task<OrderHeader> AddOrderHeaderAsync(OrderHeader orderHeader);
        Task<OrderDetails> AddOrderDetailsAsync(OrderDetails orderDetails);
        Task<IEnumerable<OrderHeader>> GetAllAsync();
        Task<IEnumerable<OrderHeader>> GetAllByUserIdAsync(string UserId);
        Task<OrderHeader> GetByIdAsync(Guid orderHeaderId);
        Task<string?> UpdateStatusAsync(Guid orderHeaderId, string newStatus);
        Task<OrderHeader?> UpdateOrderHeaderAsync(OrderHeader orderHeader);

    }
}
