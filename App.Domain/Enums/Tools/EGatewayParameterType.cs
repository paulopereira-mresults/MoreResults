using System.ComponentModel.DataAnnotations;

namespace App.Domain.Enums.Tools;

/// <summary>
/// Tipos possíveis de parâmetros.
/// </summary>
public enum EGatewayParameterType: int
{
    [Display(Name = "Boleano")]
    Boolean = 1,

    [Display(Name = "Número inteiro")]
    Integer = 2,

    [Display(Name = "Número decimal")]
    Decimal = 3,

    [Display(Name = "Texto")]
    String = 4,

    [Display(Name = "Data e hora")]
    Datetime = 5,

    [Display(Name = "Data")]
    Date = 6,

    [Display(Name = "Hora")]
    Hour = 7
}
