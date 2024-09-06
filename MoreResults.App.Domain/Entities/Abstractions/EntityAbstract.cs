namespace MoreResults.App.Domain.Entities.Abstractions;

public abstract class EntityAbstract
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
