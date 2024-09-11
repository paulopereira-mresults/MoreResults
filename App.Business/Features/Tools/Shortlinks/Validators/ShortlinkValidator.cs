using App.Business.Features.Abstractions;
using App.Domain.Entities.Tools;

namespace App.Business.Features.Tools.Shortlinks.Validators;

public class ShortlinkValidator : ValidatorAbstract<Shortlink>
{
    public ValidatorAbstract<Shortlink> ValidationForAddOrUpdate(Shortlink? shortlink)
    {
        if (shortlink is null)
        {
            Requires()
                .IsNotNull(shortlink, nameof(Shortlink), "O link não existe.");
            return this;
        }

        Requires()
            .IsLowerOrEqualsThan(shortlink.Code.Length, 4, nameof(shortlink.Code), "Código gerado incorretamente.")
            .IsGreaterOrEqualsThan(shortlink.Resume, 10, nameof(shortlink.Resume), "Mínimo: 10 caracteres.")
            .IsLowerOrEqualsThan(shortlink.Resume, 100, nameof(shortlink.Resume), "Máximo: 100 caracteres.")
            .IsUrlOrEmpty(shortlink.Link, nameof(shortlink.Link), "Link inválido")
            ;

        return this;
    }

    public ValidatorAbstract<Shortlink> ValidationForDelete(Shortlink? shortlink)
    {
        Requires()
            .IsNotNull(shortlink, nameof(Shortlink), "O link a ser apagado não existe.");

        return this;
    }
}
