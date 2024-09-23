using App.Domain.Entities.Abstractions;

namespace App.Domain.Entities.Tools;

public class GatewayCredential:EntityAbstract
{
    /// <summary>
    /// ID do gateway a que pertence esta credencial.
    /// </summary>
    public int GatewayId { get; set; }

    /// <summary>
    /// Chave
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Valor
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Instância do Gateway a que pertence estas credenciais.
    /// </summary>
    public Gateway GatewayInstance { get; set; }

    public GatewayCredential() { }

    public GatewayCredential(int gatewayId, string key, string value)
    {
        GatewayId = gatewayId;
        Key = key;
        Value = value;

        CreateDate = DateTime.Now;
    }

    public void Update(string key, string value)
    {
        Key = key;
        Value = value;

        UpdateDate = DateTime.Now;
    }
}
