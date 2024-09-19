using App.Domain.Entities.Abstractions;

namespace App.Domain.Entities.Tools;

/// <summary>
/// Agendamentos de tarefas a serem executados nos middlewares. Para este feito, será utilizada a biblioteca Hangfire.
/// </summary>
public class GatewaySchedule:EntityAbstract
{
    /// <summary>
    /// Gateway a ser executado por padrão.
    /// </summary>
    public int GatewayId { get; set; }

    /// <summary>
    /// Breve descrição do agendamento.
    /// </summary>
    public string Resume { get; set; }

    /// <summary>
    /// Expressão cron a ser utilizada no agendamento.
    /// </summary>
    public string Cron { get; set; }

    /// <summary>
    /// Nome do trabalho agendado.
    /// </summary>
    public string Job { get; set; }
}
