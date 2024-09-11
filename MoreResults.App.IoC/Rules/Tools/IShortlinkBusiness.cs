using MoreResults.App.Domain.Dto;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC.Abstractions;

namespace MoreResults.App.IoC.Rules.Tools;

public interface IShortlinkBusiness: IBusiness
{
    /// <summary>
    /// Alista todos os links cadastrados
    /// </summary>
    Task<DefaultResponseDto<IEnumerable<Shortlink>>> List(CancellationToken cancellationToken);

    /// <summary>
    /// Recupera um link a partir do ID.
    /// </summary>
    Task<DefaultResponseDto<Shortlink>> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Recupera recupera um link a partir do código.
    /// </summary>
    /// <param name="code">Código do link encurtado.</param>
    Task<DefaultResponseDto<Shortlink>> GetByCodeAsync(string code, CancellationToken cancellationToken);

    /// <summary>
    /// Salva o registro de um novo shortlink
    /// </summary>
    Task<DefaultResponseDto<Shortlink>> AddAsync(Shortlink shortlink, CancellationToken cancellationToken);

    /// <summary>
    /// Atualiza as informações de um shortlink existente
    /// </summary>
    Task<DefaultResponseDto<Shortlink>> UpdateAsync(Shortlink shortlink, CancellationToken cancellationToken);

    /// <summary>
    /// Apaga um link a partir do ID
    /// </summary>
    Task<DefaultResponseDto<bool>> DeleteAsync(int id, CancellationToken cancellationToken);
}
