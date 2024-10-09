using System.ComponentModel.DataAnnotations;

namespace App.Domain.Enums.Tools;

public enum EGatewayType : int
{
  [Display(Name = "Banco de dados")]
  Database = 1,
}
