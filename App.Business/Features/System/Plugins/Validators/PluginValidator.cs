using App.Business.Features.Abstractions;
using App.Domain.Entities.System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace App.Business.Features.System.Plugins.Validators;

public class PluginValidator : ValidatorAbstract<Plugin>
{
  public ValidatorAbstract<Plugin> ValidationForAddOrUpdate(Plugin? plugin)
  {
    Requires()
        .AreEquals(plugin.Code.Length, 5, nameof(plugin.Code), "Código para o plugin inválido.")
        .IsGreaterOrEqualsThan(plugin.Controller.Length, 10, nameof(plugin.Resume), "Mínimo: 20 caracteres.")
        .IsGreaterOrEqualsThan(plugin.Resume.Length, 20, nameof(plugin.Resume), "Mínimo: 20 caracteres.")
        .IsGreaterOrEqualsThan(plugin.Source.Length, 20, nameof(plugin.Resume), "Mínimo: 20 caracteres.")

        .IsLowerOrEqualsThan(plugin.Controller.Length, 100, nameof(plugin.Resume), "Máximo: 100 caracteres.")
        .IsLowerOrEqualsThan(plugin.Resume.Length, 250, nameof(plugin.Resume), "Máximo: 250 caracteres.")
        .IsLowerOrEqualsThan(plugin.Source.Length, 65000, nameof(plugin.Resume), "Máximo: 65.000 caracteres.")
        ;

    IEnumerable<string> sourceValidator = ValidateCode(plugin.Source);

    foreach (string validator in sourceValidator)
    {
      AddNotification(nameof(plugin.Source), $"Erro no código fonte: {validator}");
    }

    return this;
  }

  /// <summary>
  /// Valida se um trecho de código em C# está válido.
  /// </summary>
  private IEnumerable<string> ValidateCode(string source)
  {
    var syntaxTree = CSharpSyntaxTree.ParseText(source);

    var compilation = CSharpCompilation.Create(
        "CodeValidation",
        new[] { syntaxTree },
        new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) },
        new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

    var diagnostics = compilation.GetDiagnostics();

    return diagnostics
        .Where(d => d.Severity == DiagnosticSeverity.Error)
        .Select(d => d.GetMessage());
  }
}
