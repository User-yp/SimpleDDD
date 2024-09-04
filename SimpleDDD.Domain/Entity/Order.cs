namespace SimpleDDD.Domain.Entity;

public class Order : BaseEntity
{
    public Guid Id { get; init; }= Guid.NewGuid();
    public string OrderName { get;private set; }
    public string Description{ get; private set; }
    public Guid TableId { get; private set; }
    public Table Table { get; private set; }
    public DateTime CreationTime { get; private set; }=DateTime.Now;
    public DateTime? DeletionTime { get; private set; }
    public DateTime? LastModificationTime { get; private set; }
    public bool IsDeleted { get; private set; }

    public Order()
    {
        
    }
    public Order(string OrderName, string Description)
    {
        this.OrderName = OrderName;
        this.Description = Description;
    }
    public void ChangeOrderName(string orderName)
    {
        OrderName = orderName;
    }
    public void SetTable(Table table)
    {
        this.TableId = table.Id;    
    }
    public void NotifyModified()
    {
        LastModificationTime = DateTime.Now;
    }

    public void SoftDelete()
    {
        IsDeleted = true;
        DeletionTime = DateTime.Now;
    }
}
