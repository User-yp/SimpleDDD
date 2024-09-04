using Microsoft.AspNetCore.Mvc;
using SimpleDDD.Domain;
using SimpleDDD.Domain.Entity;
using SimpleDDD.Domain.Repository;
using SimpleDDD.Infrastructure;

namespace SimpleDDD.WebApi.Controllers;

[Route("api/[action]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IDomainService domainService;
    private readonly IOrderRepository orderRepository;
    private readonly BaseDbContext dbContext;

    public OrderController(IDomainService domainService,IOrderRepository orderRepository,BaseDbContext dbContext)
    {
        this.domainService = domainService;
        this.orderRepository = orderRepository;
        this.dbContext = dbContext;
    }
    [HttpPost]
    public async Task<ActionResult> InitAsync()
    {
        Table table1 = new Table("测试表1", DateTime.Now.ToString("G"));
        Table table2 = new Table("测试表2", DateTime.Now.ToString("G"));
        Table table3 = new Table("测试表3", DateTime.Now.ToString("G"));

        List<Order> orders = [];

        for (int i = 1; i < 20; i++)
        {
            Order order = new($"测试订单{i}", $"测试订单描述{i}");
            order.SetTable(table1);
            orders.Add(order);
        }
        for (int i = 20; i < 40; i++)
        {
            Order order = new($"测试订单{i}", $"测试订单描述{i}");
            order.SetTable(table2);
            orders.Add(order);
        }
        for (int i = 40; i < 60; i++)
        {
            Order order = new($"测试订单{i}", $"测试订单描述{i}");
            order.SetTable(table3);
            orders.Add(order);
        }

        await dbContext.Tables.AddRangeAsync(table1, table2, table3);
        await dbContext.Orders.AddRangeAsync(orders);
        await dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpGet(Endpoint.Order.Get)]
    public async Task<ActionResult<Order>> GetOrderByIdAsync([FromRoute] Guid id)
    {
        (var ope, var res) = await domainService.GetOrderById(id);
        if (!ope.Succeeded)
            return BadRequest(ope.Errors);
        return Ok(res);
    }

    [HttpGet(Endpoint.Order.GetAll)]
    public async Task<ActionResult<List<Order>>> GetAllOrderAsync()
    {
        (var ope, var res) = await domainService.GetAllOrderAsync();
        if (!ope.Succeeded)
            return BadRequest(ope.Errors);
        return Ok(res);
    }
    [HttpGet(Endpoint.Order.GetByName)]
    public async Task<ActionResult<Order>> GetOrderByNameAsync([FromRoute] string name)
    {
        (var ope, var res) = await domainService.GetOrderByNameAsync(name);
        if (!ope.Succeeded)
            return BadRequest(ope.Errors);
        return Ok(res);
    }

    [HttpGet(Endpoint.Order.GetByTableId)]
    public async Task<ActionResult<List<Order>>> GetOrdersByTableIdAsync([FromRoute] Guid tableId)
    {
        (var ope, var res) = await domainService.GetOrdersByTableIdAsync(tableId);
        if (!ope.Succeeded)
            return BadRequest(ope.Errors);
        return Ok(res);
    }

    [HttpGet(Endpoint.Order.GetByTableName)]
    public async Task<ActionResult<List<Order>>> GetOrdersByTableNameAsync([FromRoute] string tableName)
    {
        (var ope, var res) = await domainService.GetOrdersByTableNameAsync(tableName);
        if (!ope.Succeeded)
            return BadRequest(ope.Errors);
        return Ok(res);
    }
}
