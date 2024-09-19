using App.Domain.Entities.Abstractions;

namespace App.Domain.Entities.Tools;

/// <summary>
/// Categorias dos gateways
/// </summary>
public class GatewayCategory:EntityAbstract
{
    /// <summary>
    /// Nome da categoria
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Descrição resumida da categoria.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Lista de gateways pertencentes a categoria.
    /// </summary>
    public ICollection<Gateway> Gateways { get; set; }
}
