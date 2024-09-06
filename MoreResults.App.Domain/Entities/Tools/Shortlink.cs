using MoreResults.App.Domain.Entities.Abstractions;
using MoreResults.App.Shared.ExtensionMethods;

namespace MoreResults.App.Domain.Entities.Tools;

public class Shortlink: EntityAbstract
{
    public string Code { get; set; }
    public string Link { get; set; }
    public string Resume { get; set; }

    public virtual ICollection<ShortlinkAccess> Accesses { get; set; }

    public Shortlink(string link, string resume)
    {
        Code = "ABCDEFGHIJLMNOPQRSTUVXZKWY0123456789".GenerateRandomCode(4);
        Link = link;
        Resume = resume;
    }

    public Shortlink Update(string link, string resume)
    { 
        Link = link;
        Resume = resume;
        return this;
    }

    public Shortlink() { }
}
