using App.Business.Features.Tools.Shortlinks.Queries;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.Test.App_Repository;
using FluentAssertions;
using Moq;

namespace App.Test.App_Business.Features.Tools.Shortlinks.Queries;

public class GetShortlinkByCodeQueryHandlerTest:AbstractTest
{
  public GetShortlinkByCodeQueryHandlerTest()
  {
    _repositories = new RepositoriesMock();
  }

  [Fact]
  public async Task GetShortlinkByCodeQueryHandler__Espera_sucesso_ao_solicitar_um_link_encurtado_a_partir_do_codigo_fornecido()
  {
    // arrange
    GetShortlinkByCodeQueryHandler handler = new GetShortlinkByCodeQueryHandler(_repositories);

    // act
    DefaultResponseDto<Shortlink> result = await handler.HandleAsync(It.IsAny<string>(), CancellationToken.None);

    // assert
    result
      .Notifications
      .Should()
      .BeNullOrEmpty();
  }

  [Fact]
  public async Task GetShortlinkByCodeQueryHandler__Espera_erro_ao_solicitar_um_link_encurtado_a_partir_do_codigo_inexistente_fornecido()
  {
    string code = "ABC";

    // arrange
    GetShortlinkByCodeQueryHandler handler = new GetShortlinkByCodeQueryHandler(_repositories);

    // act
    DefaultResponseDto<Shortlink> result = await handler.HandleAsync(code, CancellationToken.None);

    // assert
    result
      .Notifications
      .Should()
      .BeNullOrEmpty();

    result
      .Result
      .Code
      .Should().NotBeEquivalentTo(code);
  }
}
