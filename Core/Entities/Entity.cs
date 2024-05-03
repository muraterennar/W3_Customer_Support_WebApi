namespace Core.Entities;

public class Entity<TId>
{
    public TId Id { get; set; }
    public DateTime? RECORD_DATE { get; set; }
    public int? RECORD_EMP { get; set; }
    public string? RECORD_IP { get; set; }
    public DateTime? UPDATE_DATE { get; set; }
    public int? UPDATE_EMP { get; set; }
    public string? UPDATE_IP { get; set; }
}