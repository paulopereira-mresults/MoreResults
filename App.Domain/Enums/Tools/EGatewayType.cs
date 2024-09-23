using System.ComponentModel.DataAnnotations;

namespace App.Domain.Enums.Tools;

public enum EGatewayType : int
{
    [Display(Name = "Banco de dados MySQL")]
    DBMySQL = 11,

    [Display(Name = "Banco de dados SQL Server")]
    DBSQLServer = 12
}
