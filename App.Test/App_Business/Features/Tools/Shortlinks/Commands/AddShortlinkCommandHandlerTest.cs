using App.Business.Features.Tools.Shortlinks.Commands;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.Test.App_Repository.Repositories;
using FluentAssertions;

namespace App.Test.App_Business.Features.Tools.Shortlinks.Commands;

public class AddShortlinkCommandHandlerTest : AbstractTest
{
  [Fact]
  public async Task AddShortlinkCommandHandler__Espera_sucesso_ao_adicionar_link()
  {
    // Arrange
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
      .WithCorrectlyAddedLink(shortlink)
      .Generate();

    AddShortlinkCommandHandler handler = new AddShortlinkCommandHandler(_repositories);

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
}
