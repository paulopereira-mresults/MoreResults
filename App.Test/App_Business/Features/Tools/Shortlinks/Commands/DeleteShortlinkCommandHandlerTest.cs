using App.Business.Features.Tools.Shortlinks.Commands;
using App.Domain.Dto;
using App.Test.App_Repository.Repositories;
using FluentAssertions;

namespace App.Test.App_Business.Features.Tools.Shortlinks.Commands;

public class DeleteShortlinkCommandHandlerTest : AbstractTest
{
  [Fact]
  public async Task DeleteShortlinkCommandHandler__Espera_sucesso_ao_apagar_link()
  {
    _repositories.Shortlink = new ShortlinkRepositoryMock()
      .WithCorrectlyLink()
      .WithCorrectlyDeletedLink()
      .Generate();

    _repositories.ShortlinkAccess = new ShortlinkAccessRepositoryMock().WithCorrectlyAccess().Generate();

    // Arrange
    DeleteShortlinkCommandHandler handler = new DeleteShortlinkCommandHandler(_repositories);

    // Act
    DefaultResponseDto<bool> result = await handler.HandleAsync(1, CancellationToken.None);

    // Assert
    result
      .Notifications
      .Should()
      .BeNullOrEmpty();

    result
      .Result
      .Should()
      .Be(true);
  }

  [Fact]
  public async Task DeleteShortlinkCommandHandler__Espera_falha_ao_apagar_link_inexistente()
  {
    _repositories.Shortlink = new ShortlinkRepositoryMock()
      .WithNullableLink()
      .WithFailOnDeletedLink()
      .Generate();
    
    _repositories.ShortlinkAccess = new ShortlinkAccessRepositoryMock().WithCorrectlyAccess().Generate();

    // Arrange
    DeleteShortlinkCommandHandler handler = new DeleteShortlinkCommandHandler(_repositories);

    // Act
    DefaultResponseDto<bool> result = await handler.HandleAsync(1, CancellationToken.None);

    // Assert
    result
      .Notifications
      .Should()
      .NotBeNullOrEmpty();

    result
      .Result
      .Should()
      .Be(false);

    result
      .Notifications
      .Should()
      .Contain(x => x.Message == "O link a ser apagado não existe." && x.Key == "Shortlink");
  }
}
