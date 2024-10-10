using App.Business.Features.Tools.Shortlinks.Commands;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.Test.App_Repository.Repositories;
using FluentAssertions;

namespace App.Test.App_Business.Features.Tools.Shortlinks.Commands;

public class UpdateShortlinkCommandHandlerTest : AbstractTest
{
  [Fact]
  public async Task UpdateShortlinkCommandHandler__Espera_sucesso_ao_editar_link()
  {
    // Arrange
    UpdateShortlinkCommandHandler handler = new UpdateShortlinkCommandHandler(_repositories);

    Shortlink shortlink = new Shortlink
    {
      Id = 1,
      Code = "ABC12",
      CreateDate = DateTime.Now,
      Link = "https://www.google.com.br",
      Resume = "Nome do link",
      UpdateDate = DateTime.Now,
    };

    _repositories.Shortlink = new ShortlinkRepositoryMock()
      .WithCorrectlyLink()
      .WithCorrectlyUpdatedLink(shortlink)
      .Generate();

    // Act
    DefaultResponseDto<Shortlink> result = await handler.HandleAsync(shortlink, CancellationToken.None);

    // Assert
    result
      .Notifications
      .Should()
      .BeNullOrEmpty();

    result
      .Result
      .Should()
      .BeEquivalentTo(shortlink);
  }

  [Fact]
  public async Task UpdateShortlinkCommandHandler__Espera_falha_ao_editar_link_inexistente()
  {
    _repositories.Shortlink = new ShortlinkRepositoryMock()
      .WithNullableLink()
      .WithFailOnDeletedLink()
      .Generate();
    
    _repositories.ShortlinkAccess = new ShortlinkAccessRepositoryMock().WithCorrectlyAccess().Generate();

    // Arrange
    UpdateShortlinkCommandHandler handler = new UpdateShortlinkCommandHandler(_repositories);
    Shortlink shortlink = new Shortlink
    {
      Id = 1,
      Code = "ABC12",
      CreateDate = DateTime.Now,
      Link = "https://www.google.com.br",
      Resume = "Nome do link",
      UpdateDate = DateTime.Now,
    };

    // Act
    DefaultResponseDto<Shortlink> result = await handler.HandleAsync(shortlink, CancellationToken.None);

    // Assert
    result
      .Notifications
      .Should()
      .NotBeNullOrEmpty();

    result
      .Result
      .Should()
      .Be(null);

    result
      .Notifications
      .Should()
      .Contain(x => x.Message == "O link não existe." && x.Key == "Shortlink");
  }
}
