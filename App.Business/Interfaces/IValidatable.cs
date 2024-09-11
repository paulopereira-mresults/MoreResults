using App.IoC.Abstractions;

namespace App.Business.Interfaces;

public interface IValidatable<T>
{
    /// <summary>
    /// Define como serão feitas as regras de negócio. São regras de negócio de como o
    /// sistema deve se comportar em relação ao armazenamento de dados e demais regras relacionadas no sistema.
    /// </summary>
    void Validate(T entity);

    /// <summary>
    /// Determina se as operações foram realizadas com sucesso e está tudo válido.
    /// </summary>
    bool IsValid { get; }

    /// <summary>
    /// Determina se as operações foram realizadas e há falha na operação.
    /// </summary>
    bool Invalid { get; }
}

