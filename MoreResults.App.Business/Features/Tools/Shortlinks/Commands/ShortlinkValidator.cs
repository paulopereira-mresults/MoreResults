using Flunt.Validations;
using MoreResults.App.Business.Interfaces;
using MoreResults.App.Domain.Entities.Tools;


namespace MoreResults.App.Business.Features.Tools.Shortlinks.Commands;

public class ShortlinkValidator: Contract<Shortlink>, IValidatable<Shortlink>
{
    public void Validate(Shortlink shortlink)
    {
        Requires()
            .AreEquals(shortlink.Code.Length, 5, nameof(shortlink.Code), "Código definido incorretamente.")
            .IsGreaterOrEqualsThan(shortlink.Resume, 10, nameof(shortlink.Resume), "Mínimo: 10 caracteres.")
            .IsLowerOrEqualsThan(shortlink.Resume, 100, nameof(shortlink.Resume), "Máximo: 100 caracteres.")
            .IsUrlOrEmpty(shortlink.Link, nameof(shortlink.Link), "Link inválido")
            ;
    }
}
