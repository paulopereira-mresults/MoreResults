using App.Domain.Entities.Abstractions;
using App.Shared.Helpers;

namespace App.Domain.Entities.System;

/// <summary>
/// Plugins podem ser desenvolvidos para interceptar ações antes e depois da execução dos controllers.
/// </summary>
public class Plugin : EntityAbstract
{
  /// <summary>
  /// Código alfanumerico único para identificar o plugin
  /// </summary>
  public string Code { get; set; }

  /// <summary>
  /// Nome do controller que será interceptado.
  /// </summary>
  public string Controller { get; set; }

  /// <summary>
  /// Resumo descritivo das funções do plugin
  /// </summary>
  public string Resume { get; set; }

  /// <summary>
  /// Determina se o plugin está ou não ativo.
  /// </summary>
  public bool IsActive { get; set; }

  /// <summary>
  /// Código fonte do plugin que fará a interceptação do controller.
  /// </summary>
  public string Source { get; set; }

  public Plugin()
  {
    Code = StringHelper.GenerateRandomCode(5);
    CreateDate = DateTime.Now;
    IsActive = true;
  }

  public Plugin(string controller, string resume, string source) : this()
  {
    Controller = controller;
    Resume = resume;
    Source = source;
  }

  public void Update(string controller, string resume, string source, bool isActive)
  {
    Controller = controller;
    Resume = resume;
    Source = source;
    IsActive = isActive;
  }
}
