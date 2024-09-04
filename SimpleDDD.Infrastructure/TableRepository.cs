using Microsoft.EntityFrameworkCore;
using SimpleDDD.Domain.Entity;
using SimpleDDD.Domain.Repository;

namespace SimpleDDD.Infrastructure;

public class TableRepository(BaseDbContext dbContext) : ITableRepository
{
    private readonly BaseDbContext dbContext = dbContext;

    public async Task<List<Table>?> GetAllTablesAsync()
    {
        return await dbContext.Tables.ToListAsync();
    }

    public async Task<Table?> GetOrderBelongTableAsync(Order order)
    {
        return await dbContext.Tables.FirstOrDefaultAsync(t => t.Id == order.Id);
    }

    public async Task<Table?> GetTableByIdAsync(Guid id)
    {
        return await dbContext.Tables.FirstOrDefaultAsync(t => t.Id == id);
    }

    public Task<Table?> GetTableByNameAsync(string tableName)
    {
        return dbContext.Tables.FirstOrDefaultAsync(t=>t.TableName == tableName);
    }
}
