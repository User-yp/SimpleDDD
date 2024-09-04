using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleDDD.Domain;
using SimpleDDD.Domain.Entity;
using SimpleDDD.Domain.Repository;
using SimpleDDD.Infrastructure;

namespace SimpleDDD.WebApi.Controllers;

[Route("api")]
[ApiController]
public class TableController : ControllerBase
{
    private readonly BaseDbContext dbContext;
    private readonly IDomainService domainService;
    private readonly ITableRepository tableRepository;

    public TableController(BaseDbContext dbContext,IDomainService domainService ,ITableRepository tableRepository)
    {
        this.dbContext = dbContext;
        this.domainService = domainService;
        this.tableRepository = tableRepository;
    }

    [HttpGet(Endpoint.Table.GetAll)]
    public async Task<ActionResult<List<Table>>> GetAllTablesAsync()
    {
        (var ope, var res) = await domainService.GetAllTablesAsync();
        if (!ope.Succeeded)
            return BadRequest(ope.Errors);
        return Ok(res);
    }

    [HttpGet(Endpoint.Table.Get)]
    public async Task<ActionResult<Table>> GetTableByIdAsync([FromRoute] Guid id)
    {
        (var ope, var res) = await domainService.GetTableByIdAsync(id);
        if (!ope.Succeeded)
            return BadRequest(ope.Errors);
        return Ok(res);
    }

    [HttpGet(Endpoint.Table.GetByOrderName)]
    public async Task<ActionResult<Table>> GetOrderBelongTableAsync([FromRoute] Guid id)
    {
        (var ope, var res) = await domainService.GetOrderBelongTableAsync(id);
        if (!ope.Succeeded)
            return BadRequest(ope.Errors);
        return Ok(res);
    }
}
