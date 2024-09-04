namespace SimpleDDD.Domain.Entity;

public class Table: BaseEntity
{
    public Guid Id { get; init; }= Guid.NewGuid();

    public string TableName { get; private set; }

    public string TableNumber { get; private set; }

    public List<Order> Orders { get; private set; } = [];

    public DateTime CreationTime { get; private set; }= DateTime.Now;

    public DateTime? DeletionTime { get; private set; }

    public DateTime? LastModificationTime { get; private set; }     

    public bool IsDeleted { get; private set; }

    public Table()
    {
        
    }
    public Table(string TableName, string TableNumber)
    {
        this.TableName = TableName;
        this.TableNumber = TableNumber;
    }
    public void ChangeTableName(string tableName)
    {
        TableName = tableName;
        NotifyModified();
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
