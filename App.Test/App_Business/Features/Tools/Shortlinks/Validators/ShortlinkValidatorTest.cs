using App.Business.Features.Tools.Shortlinks.Validators;
using App.Domain.Entities.Tools;
using Bogus;
using FluentAssertions;

namespace App.Test.App_Business.Features.Tools.Shortlinks.Validators;

public class ShortlinkValidatorTest:AbstractTest
{
  [Fact]
  public void ValidationForAddOrUpdate__Espera_sucesso_ao_enviar_dados_corretos_para_validacao()
  {
    // Arrange
    Shortlink shortlink = new Faker<Shortlink>()
      .RuleFor(x => x.Id, 0)
      .RuleFor(x => x.Code, "ABC123")
      .RuleFor(x => x.Resume, f => f.Lorem.Letter(20))
      .RuleFor(x => x.Link, f => f.Internet.Url())
      .Generate();

    ShortlinkValidator validator = new ShortlinkValidator();

    // Act
    validator.ValidationForAddOrUpdate(shortlink);

    // Assert
    validator
      .Notifications
      .Should()
      .BeNullOrEmpty();
  }

  [Fact]
  public void ValidationForAddOrUpdate__Espera_erro_ao_enviar_link_nulo_para_validacao()
  {
    // Arrange
    Shortlink? shortlink = null;

    ShortlinkValidator validator = new ShortlinkValidator();

    // Act
    validator.ValidationForAddOrUpdate(shortlink);

    // Assert
    validator
      .Notifications
      .Should()
      .NotBeNullOrEmpty();

    validator
      .Notifications
      .Should()
      .Contain(n => n.Message == "O link não existe." && n.Key == "Shortlink");
  }

  [Theory]
  [InlineData("A", "Link com código inválido", "https://www.google.com.br", "Código gerado com erros.", "Code")]
  [InlineData("ABC2", "Resumo", "https://www.google.com.br", "Mínimo: 10 caracteres.", "Resume")]
  [InlineData("ABC2", "Link com resumo grande demais. A descrição contém acima de 100 caracteres. Então retornará erro.Link com resumo grande demais. A descrição contém acima de 100 caracteres. Então retornará erro.", "https://www.google.com.br", "Máximo: 100 caracteres.", "Resume")]
  [InlineData("ABC2", "O link informado é inválido.", "https://www.", "Link inválido.", "Link")]
  public void ValidationForAddOrUpdate__Espera_erros_ao_enviar_dados_invalidos_para_validacao(string code, string resume, string link, string expectedErrorMessage, string propertyKey)
  {
    // Arrange
    Shortlink? shortlink = new Shortlink
    {
      Code = code,
      Resume = resume,
      Link = link
    };

    ShortlinkValidator validator = new ShortlinkValidator();

    // Act
    validator.ValidationForAddOrUpdate(shortlink);

    // Assert
    validator
      .Notifications
      .Should()
      .NotBeNullOrEmpty();

    validator
      .Notifications
      .Should()
      .Contain(n => n.Message == expectedErrorMessage && n.Key == propertyKey);
  }

  [Fact]
  public void ValidationForDelete__Espera_erro_ao_enviar_link_nulo_para_validacao()
  {
    // Arrange
    Shortlink? shortlink = null;

    ShortlinkValidator validator = new ShortlinkValidator();

    // Act
    validator.ValidationForDelete(shortlink);

    // Assert
    validator
      .Notifications
      .Should()
      .NotBeNullOrEmpty();

    validator
      .Notifications
      .Should()
      .Contain(n => n.Message == "O link a ser apagado não existe." && n.Key == "Shortlink");
  }


  [Fact]
  public void ValidationForGet__Espera_erro_ao_enviar_link_nulo_para_validacao()
  {
    // Arrange
    Shortlink? shortlink = null;

    ShortlinkValidator validator = new ShortlinkValidator();

    // Act
    validator.ValidationForGet(shortlink);

    // Assert
    validator
      .Notifications
      .Should()
      .NotBeNullOrEmpty();

    validator
      .Notifications
      .Should()
      .Contain(n => n.Message == "O link não existe." && n.Key == "Shortlink");
  }

}
