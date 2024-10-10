using App.Business.Features.Tools.Shortlinks.Commands;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.Test.App_Repository.Repositories;
using FluentAssertions;

namespace App.Test.App_Business.Features.Tools.Shortlinks.Commands;

public class AddOneVisitorOnShortlinkCommandHandlerTest : AbstractTest
{
  [Fact]
  public async Task AddOneVisitorOnShortlinkCommandHandler__Espera_sucesso_ao_adicionar_acesso()
  {
    // Arrange
    Shortlink shortlink = new Shortlink();

    _repositories.ShortlinkAccess = new ShortlinkAccessRepositoryMock()
      .WithCorrectlyAccess()
      .WithCorrectlyAddedAccess()
      .Generate();

    AddOneVisitorOnShortlinkCommandHandler handler = new AddOneVisitorOnShortlinkCommandHandler(_repositories);

    // Act
    bool result = await handler.HandleAsync(shortlink, CancellationToken.None);

    // Assert
    result
      .Should().BeTrue();
  }
}
