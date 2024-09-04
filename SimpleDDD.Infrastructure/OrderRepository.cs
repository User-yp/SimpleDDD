using Microsoft.EntityFrameworkCore;
using SimpleDDD.Domain.Entity;
using SimpleDDD.Domain.Repository;

namespace SimpleDDD.Infrastructure;

public class OrderRepository(BaseDbContext dbContext,ITableRepository tableRepository) : IOrderRepository
{
    private readonly BaseDbContext dbContext = dbContext;
    private readonly ITableRepository tableRepository = tableRepository;

    public async Task<List<Order>?> GetAllOrdersAsync()
    {
        return await dbContext.Orders.ToListAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(Guid guid)
    {
        return await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == guid);
    }

    public async Task<Order?> GetOrderByNameAsync(string name)
    {
        return await dbContext.Orders.FirstOrDefaultAsync(o => o.OrderName == name);
    }

    public async Task<List<Order>?> GetOrdersByTableIdAsync(Guid tableId)
    {
        return await dbContext.Orders.Where(o=>o.TableId==tableId).ToListAsync();
    }

    public async Task<List<Order>?> GetOrdersByTableNameAsync(string tableName)
    {
        var table= await tableRepository.GetTableByNameAsync(tableName);
        return await dbContext.Orders.Where(o => o.TableId == table.Id).ToListAsync();
    }
}
