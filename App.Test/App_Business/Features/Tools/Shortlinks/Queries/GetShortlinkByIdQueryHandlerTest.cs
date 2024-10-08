﻿using App.Business.Features.Tools.Shortlinks.Queries;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.Test.App_Repository.Repositories;
using FluentAssertions;

namespace App.Test.App_Business.Features.Tools.Shortlinks.Queries;

public class GetShortlinkByIdQueryHandlerTest : AbstractTest
{
  [Fact]
  public async Task GetShortlinkByIdQueryHandler_Espera_sucesso_ao_buscar_por_link_encurtado_pelo_ID()
  {
    _repositories.Shortlink = new ShortlinkRepositoryMock().WithCorrectlyLink().Generate();
    _repositories.ShortlinkAccess = new ShortlinkAccessRepositoryMock().WithCorrectlyAccess().Generate();

    // arrange
    GetShortlinkByIdQueryHandler handler = new GetShortlinkByIdQueryHandler(_repositories);

    // act
    DefaultResponseDto<Shortlink> result = await handler.HandleAsync(1, CancellationToken.None);

    // assert
    result
      .Notifications
      .Should()
      .BeNullOrEmpty();
  }
}
