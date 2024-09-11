using App.Domain.Entities.Abstractions;

namespace App.Domain.Entities.Tools;

/// <summary>
/// Entidade que mantém um histórico de acesso aos links encurtados.
/// </summary>
public class ShortlinkAccess: EntityAbstract
{
    public int ShortlinkId { get; set; }
    public string Ip { get; set; }
    public virtual Shortlink Shortlink { get; set; }

    public ShortlinkAccess(int shortlinkId, string ip)
    {
        ShortlinkId = shortlinkId;
        Ip = ip;
        CreateDate = DateTime.Now;
    }

    public ShortlinkAccess()
    {
        CreateDate = DateTime.Now;
    }
}
