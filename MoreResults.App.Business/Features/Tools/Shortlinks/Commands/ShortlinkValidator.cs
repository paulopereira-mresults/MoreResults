using MoreResults.App.Business.Features.Abstractions;
using MoreResults.App.Domain.Entities.Tools;

namespace MoreResults.App.Business.Features.Tools.Shortlinks.Commands;

public class ShortlinkValidator : ValidatorAbstract<Shortlink>
{
    public ValidatorAbstract<Shortlink> Validate(Shortlink? shortlink)
    {
        if (shortlink is null)
        {
            AddNotification(nameof(Shortlink), "O link não existe.");
            return this;
        }

        Requires()
            .AreEquals(shortlink.Code.Length, 5, nameof(shortlink.Code), "Código gerado incorretamente.")
            .IsGreaterOrEqualsThan(shortlink.Resume, 10, nameof(shortlink.Resume), "Mínimo: 10 caracteres.")
            .IsLowerOrEqualsThan(shortlink.Resume, 100, nameof(shortlink.Resume), "Máximo: 100 caracteres.")
            .IsUrlOrEmpty(shortlink.Link, nameof(shortlink.Link), "Link inválido")
            ;

        return this;
    }
}
