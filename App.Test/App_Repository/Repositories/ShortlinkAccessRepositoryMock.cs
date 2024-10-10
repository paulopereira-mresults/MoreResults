using App.Domain.Entities.Tools;
using App.IoC.Repositories.Tools;
using Bogus;
using Moq;

namespace App.Test.App_Repository.Repositories;

public class ShortlinkAccessRepositoryMock
{
  public IShortlinkAccessRepository Mock { get; private set; }

  public ShortlinkAccessRepositoryMock()
  {
    ShortlinkAccess shortlinkAccess = new Faker<ShortlinkAccess>()
      .RuleFor(x => x.Id, 1)
      .RuleFor(x => x.ShortlinkId, 1)
      .RuleFor(x => x.Ip, f => f.Internet.Ip())
      .Generate();

    Mock<IShortlinkAccessRepository> mock = new Mock<IShortlinkAccessRepository>();
    mock.Setup(x => x.AddAsync(It.IsAny<ShortlinkAccess>(), CancellationToken.None).Result).Returns(shortlinkAccess);

    Mock = mock.Object;
  }
}
