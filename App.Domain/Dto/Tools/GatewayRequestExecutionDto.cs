using App.Domain.Entities.Tools;

namespace App.Domain.Dto.Tools;

public class GatewayRequestExecutionDto
{
    public HttpMethod Method { get; set; }
    public string Code { get; set; }
    public Dictionary<string, string> Parameters { get; set; }
    public Gateway Gateway { get; set; }
}
