using SimpleDDD.Domain.Entity;

namespace SimpleDDD.Domain.Repository;

public interface ITableRepository
{
    Task<List<Table>?> GetAllTablesAsync(); // 获取所有订单表
    Task<Table?> GetTableByNameAsync(string tableName); // 根据表名获取订单表
    Task<Table?> GetTableByIdAsync(Guid id); // 根据表Id获取订单表
    Task<Table?> GetOrderBelongTableAsync(Order order);//查看订单所属订单表

}
