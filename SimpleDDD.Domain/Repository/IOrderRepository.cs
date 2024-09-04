using SimpleDDD.Domain.Entity;

namespace SimpleDDD.Domain.Repository;

public interface IOrderRepository
{
    Task<List<Order>?> GetAllOrdersAsync(); // 获取所有订单
    Task<Order?> GetOrderByIdAsync(Guid guid);// 根据订单Id获取订单
    Task<Order?> GetOrderByNameAsync(string name);// 根据订单Id获取订单

    Task<List<Order>?> GetOrdersByTableIdAsync(Guid tableId);//根据订单表Id获取所有订单
    Task<List<Order>?> GetOrdersByTableNameAsync(string tableName);//根据订单表Name获取所有订单
}
