using App.Domain.Dto;
using App.Domain.Entities.System;
using App.IoC.Abstractions;

namespace App.IoC.Rules.System;

public interface IPluginBusiness:IBusiness
{
    /// <summary>
    /// Alista todos os plugins existentes no sistema
    /// </summary>
    Task<DefaultResponseDto<IEnumerable<Plugin>>> ListAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Recupera as informações de um plugin específico a partir de um ID.
    /// </summary>
    Task<DefaultResponseDto<Plugin>> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Salva um novo plugin
    /// </summary>
    Task<DefaultResponseDto<Plugin>> AddAsync(Plugin plugin, CancellationToken cancellationToken);

    /// <summary>
    /// Atualiza um plugin já cadastrado
    /// </summary>
    Task<DefaultResponseDto<Plugin>> UpdateAsync(Plugin plugin, CancellationToken cancellationToken);

    /// <summary>
    /// Apaga um plugin cadastrado
    /// </summary>
    Task<DefaultResponseDto<bool>> DeleteAsync(int id, CancellationToken cancellationToken);
}
