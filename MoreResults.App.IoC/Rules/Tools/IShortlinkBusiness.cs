using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC.Abstractions;

namespace MoreResults.App.IoC.Rules.Tools;

public interface IShortlinkBusiness: IBusiness
{
    /// <summary>
    /// Recupera recupera um link a partir do código.
    /// </summary>
    /// <param name="code">Código do link encurtado.</param>
    Task<Shortlink?> GetByCodeAsync(string code);
}
