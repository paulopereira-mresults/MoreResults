namespace App.Domain.Enums.Tools;

public enum EGatewayType : int
{
    /// <summary>
    /// Realiza operações dentro dos próprios gateways.
    /// </summary>
    Gateway = 1,

    /// <summary>
    /// Realiza operações em bancos de dados.
    /// </summary>
    Database = 2
    
}
