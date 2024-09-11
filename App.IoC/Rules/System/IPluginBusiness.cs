using App.Domain.Dto;
using App.Domain.Entities.System;
using App.IoC.Abstractions;

namespace App.IoC.Rules.System;

public interface IPluginBusiness:IBusiness
{
    /// <summary>
    /// Alista todos os plugins existentes no sistema
    /// </summary>
    Task<DefaultResponseDto<IEnumerable<Plugin>>> List(CancellationToken cancellationToken);

    /// <summary>
    /// Recupera as informações de um plugin específico a partir de um ID.
    /// </summary>
    Task<DefaultResponseDto<Plugin>> GetById(int id, CancellationToken cancellationToken);
}
