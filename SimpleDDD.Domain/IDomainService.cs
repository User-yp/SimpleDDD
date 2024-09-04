using SimpleDDD.Domain.Entity;
using SimpleDDD.Domain.Operate;
using SimpleDDD.Domain.Repository;

namespace SimpleDDD.Domain;

public class IDomainService(IOrderRepository orderRepository, ITableRepository tableRepository)
{
    private readonly IOrderRepository orderRepository = orderRepository;
    private readonly ITableRepository tableRepository = tableRepository;

    //OrderService
    public async Task<(OperateResult,List<Order>?)> GetAllOrderAsync()
    {
        var orders=await orderRepository.GetAllOrdersAsync();
        if (orders == null)
            return (OperateResult.Failed(new OperateError { Code = "InvalidOrders", Description = "NoOrders" }), null);
        else
            return (OperateResult.Success, orders);
    }
    public async Task<(OperateResult,Order?)> GetOrderById(Guid guid)
    {
        var order=await orderRepository.GetOrderByIdAsync(guid);
        if (order == null)
            return (OperateResult.Failed(new OperateError { Code = "InvalidOrder", Description = "NoOrder" }), null);
        else
            return (OperateResult.Success, order);
    }
    public async Task<(OperateResult, Order?)> GetOrderByNameAsync(string name)
    {
        var order = await orderRepository.GetOrderByNameAsync(name);
        if (order == null)
            return (OperateResult.Failed(new OperateError { Code = "InvalidOrder", Description = "NoOrder" }), null);
        else
            return (OperateResult.Success, order);
    }
    public async Task<(OperateResult, List<Order>?)> GetOrdersByTableIdAsync(Guid tableId)
    {
        var orders = await orderRepository.GetOrdersByTableIdAsync(tableId);
        if (orders == null)
            return (OperateResult.Failed(new OperateError { Code = "InvalidOrders", Description = "NoOrders" }), null);
        else
            return (OperateResult.Success, orders);
    }
    public async Task<(OperateResult, List<Order>?)> GetOrdersByTableNameAsync(string  tableName)
    {
        var orders = await orderRepository.GetOrdersByTableNameAsync(tableName);
        if (orders == null)
            return (OperateResult.Failed(new OperateError { Code = "InvalidOrders", Description = "NoOrders" }), null);
        else
            return (OperateResult.Success, orders);
    }


    //TableService
    public async Task<(OperateResult, List<Table>?)> GetAllTablesAsync()
    {
        var tables = await tableRepository.GetAllTablesAsync();
        if (tables == null)
            return (OperateResult.Failed(new OperateError { Code = "InvalidTables", Description = "NoTables" }), null);
        else
            return (OperateResult.Success, tables);
    }
    public async Task<(OperateResult, Table?)> GetTableByIdAsync(Guid guid)
    {
        var table = await tableRepository.GetTableByIdAsync(guid);
        if (table == null)
            return (OperateResult.Failed(new OperateError { Code = "InvalidTable", Description = "NoTable" }), null);
        else
            return (OperateResult.Success, table);
    }
    public async Task<(OperateResult, Table?)> GetOrderBelongTableAsync(Guid guid)
    {
        (var ope,var order)= await GetOrderById(guid);
        if (!ope.Succeeded)
            return (ope, null);
        else
        {
            var table = await tableRepository.GetOrderBelongTableAsync(order);
            if (table == null)
                return (OperateResult.Failed(new OperateError { Code = "InvalidTable", Description = "NoTable" }), null);
            else
                return (OperateResult.Success, table);
        }
    }
}
