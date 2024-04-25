using Core.Entities;

namespace Core.Security.Entities;

public class OperationClaim : Entity<int>
{
    public string Name { get; set; }

    public OperationClaim()
    {
        RECORD_DATE = DateTime.Now;
        Name = string.Empty;
    }

    public OperationClaim(string name)
    {
        Name = name;
        RECORD_DATE = DateTime.Now;
    }

    public OperationClaim(int id, string name)
    {
        Id = id;
        Name = name;
        RECORD_DATE = DateTime.Now;
    }

    public OperationClaim(int id, string name, DateTime createdDate)
    {
        Id = id;
        Name = name;
        RECORD_DATE = createdDate;
    }

    public OperationClaim(int id, string name, DateTime createdDate, DateTime? updatedDate, DateTime? deletatedDate)
    {
        Id = id;
        Name = name;
        RECORD_DATE = createdDate;
        UPDATE_DATE = updatedDate;
    }
}
