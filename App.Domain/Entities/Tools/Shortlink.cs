using App.Domain.Entities.Abstractions;
using App.Shared.ExtensionMethods;

namespace App.Domain.Entities.Tools;

public class Shortlink: EntityAbstract
{
    public string Code { get; set; }
    public string Link { get; set; }
    public string Resume { get; set; }

    public virtual ICollection<ShortlinkAccess> Accesses { get; set; }

    public Shortlink(string link, string resume)
    {
        CreateDate = DateTime.Now;
        Code = "ABCDEFGHIJLMNOPQRSTUVXZKWY0123456789".GenerateRandomCode(5);
        Link = link;
        Resume = resume;
    }

    public Shortlink Update(string link, string resume)
    { 
        UpdateDate = DateTime.Now;
        Link = link;
        Resume = resume;
        return this;
    }

    public Shortlink()
    {
        CreateDate = DateTime.Now;
        Code = "ABCDEFGHIJLMNOPQRSTUVXZKWY0123456789".GenerateRandomCode(5);
    }
}
