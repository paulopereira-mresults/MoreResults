using App.Domain.Entities.Abstractions;
using App.Domain.Enums.Tools;

namespace App.Domain.Entities.Tools;

/// <summary>
/// Armazena validações que serão feitas nos parâmetros dos gateways.
/// </summary>
public class GatewayValidation: EntityAbstract
{
    /// <summary>
    /// Parâmetro a ser validado.
    /// </summary>
    public int ParameterId { get; set; }

    /// <summary>
    /// Descrição resumida do parâmetro.
    /// </summary>
    public string Resume { get; set; }

    /// <summary>
    /// Tipo de validação. Para consultar os tipos de validações disponíveis, verifique o projeto Flunt.
    /// </summary>
    /// <see cref="https://github.com/andrebaltieri/Flunt">Flunt</see>
    public EGatewayValidationType Type { get; set; }

    /// <summary>
    /// Valor de comparação
    /// </summary>
    public string ComparisonValue { get; set; }

    /// <summary>
    /// Instância do parâmetro a ser validado.
    /// </summary>
    public GatewayParameter ParameterInstance { get; set; }
}
