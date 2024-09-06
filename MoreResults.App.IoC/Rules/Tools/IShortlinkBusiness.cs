using MoreResults.App.Domain.Dto;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC.Abstractions;

namespace MoreResults.App.IoC.Rules.Tools;

public interface IShortlinkBusiness: IBusiness
{
    /// <summary>
    /// Recupera um link a partir do ID.
    /// </summary>
    Task<DefaultResponseDto<Shortlink>> GetByIdAsync(int id);

    /// <summary>
    /// Recupera recupera um link a partir do código.
    /// </summary>
    /// <param name="code">Código do link encurtado.</param>
    Task<DefaultResponseDto<Shortlink>> GetByCodeAsync(string code);

    /// <summary>
    /// Salva o registro de um novo shortlink
    /// </summary>
    Task<DefaultResponseDto<Shortlink>> AddAsync(Shortlink shortlink);

    /// <summary>
    /// Atualiza as informações de um shortlink existente
    /// </summary>
    Task<DefaultResponseDto<Shortlink>> UpdateAsync(Shortlink shortlink);
}
