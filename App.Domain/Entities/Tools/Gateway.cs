using App.Domain.Entities.Abstractions;
using App.Domain.Enums.Tools;

namespace App.Domain.Entities.Tools;

/// <summary>
/// Gateways são mecanismos dentro do sistemas que se conectam com outras aplicações criando uma interface única de comunicação.
/// </summary>
public class Gateway : EntityAbstract
{
    /// <summary>
    /// Categoria a que pertence o gateway.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Indica se o gateway está ativo.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Código único que identifica o gateway.
    /// </summary>
    public string Code { get; set; }
    /// <summary>
    /// Título aplicado ao gateway.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Descrição resumida do gateway.
    /// </summary>
    public string Resume { get; set; }

    /// <summary>
    /// Tipo de gateway: banco de dados, endpoint restfull, etc.
    /// </summary>
    public EGatewayType Type { get; set; }

    /// <summary>
    /// Parâmetros que compõem o gateway.
    /// </summary>
    public ICollection<GatewayParameter> Parameters { get; set; }

    /// <summary>
    /// Categoria a que pertence este gateway.
    /// </summary>
    public GatewayCategory Category { get; set; }

    public Gateway()
    {
        
    }

    public Gateway(int categoryId, string code, string title, string resume, EGatewayType type)
    {
        CategoryId = categoryId;
        IsActive = false;
        Code = code;
        Title = title;
        Resume = resume;
        Type = type;
        CreateDate = DateTime.Now;
    }

    public void Update(int categoryId, bool isActive, string title, string resume, EGatewayType type)
    {
        CategoryId = categoryId;
        IsActive = isActive;
        Title = title;
        Resume = resume;
        Type = type;
        UpdateDate = DateTime.Now;
    }
}
