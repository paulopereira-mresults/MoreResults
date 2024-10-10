using App.Business.Features.Tools.Shortlinks.Queries;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.Test.App_Repository.Repositories;
using FluentAssertions;

namespace App.Test.App_Business.Features.Tools.Shortlinks.Queries;

public class ListShortlinksQueryHandlerTest: AbstractTest
{
  [Fact]
  public async Task ListShortlinksQueryHandler_Espera_uma_lista_de_links_curtos_ao_fazer_busca()
  {
    _repositories.Shortlink = new ShortlinkRepositoryMock().WithCorrectlyLinks().Generate();
    _repositories.ShortlinkAccess = new ShortlinkAccessRepositoryMock().WithCorrectlyAccess().Generate();

    // arrange
    ListShortlinksQueryHandler handler = new ListShortlinksQueryHandler(_repositories);

    // act
    DefaultResponseDto<IEnumerable<Shortlink>> result = await handler.HandleAsync(0, CancellationToken.None);

    // assert
    result
      .Notifications
      .Should()
      .BeNullOrEmpty();

    result
      .Result
      .Count()
      .Should().Be(10);
  }

}
