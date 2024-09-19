namespace App.Domain.Enums.Tools;

/// <summary>
/// Tipos possíveis de parâmetros.
/// </summary>
public enum EGatewayParameterType: int
{
    /// <summary>
    /// Número inteiro.
    /// </summary>
    Integer = 1,

    /// <summary>
    /// Número decimal.
    /// </summary>
    Decimal = 2,

    /// <summary>
    /// Texto livre
    /// </summary>
    String = 3,
}
