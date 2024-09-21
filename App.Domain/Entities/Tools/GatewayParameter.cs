using App.Domain.Entities.Abstractions;
using App.Domain.Enums.Tools;

namespace App.Domain.Entities.Tools;

/// <summary>
/// Parâmetros são são enviados aos gateways com as informações a serem requisitadas.
/// </summary>
public class GatewayParameter: EntityAbstract
{
    /// <summary>
    /// Id do Gateway a que pertence este parâmetro.
    /// </summary>
    public int GatewayId { get; set; }

    /// <summary>
    /// Determina se o parâmetro é obrigatório ou não.
    /// </summary>
    public bool IsRequired { get; set; }

    /// <summary>
    /// Nome do parâmetro. Sem acentos, caracteres especiais ou espaços. 
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Descrição resumida do parâmetro.
    /// </summary>
    public string Resume { get; set; }

    /// <summary>
    /// Tipo de dado do parâmetro: numero, texto, etc.
    /// </summary>
    public EGatewayParameterType Type { get; set; }

    /// <summary>
    /// Valor pré-definido do parâmetro. Por padrão, todos são armazenados e enviados como texto e convertido para o tipo necessário.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Instância do gateway a que pertence este parâmetro.
    /// </summary>
    public Gateway GatewayInstance { get; set; }

    /// <summary>
    /// Validações do parâmetro.
    /// </summary>
    public ICollection<GatewayValidation> Validations { get; set; }

    public GatewayParameter() { }

    public GatewayParameter(int gatewayId, bool isRequired, EGatewayParameterType type, string name, string resume, string value)
    {
        GatewayId = gatewayId;
        IsRequired = isRequired;
        Name = name;
        Resume = resume;
        Type = type;
        Value = value;
    }

    public void Update(int gatewayId, bool isRequired, EGatewayParameterType type, string name, string resume,  string value)
    {
        GatewayId = gatewayId;
        IsRequired = isRequired;
        Name = name;
        Resume = resume;
        Type = type;
        Value = value;
    }
}
