using App.Domain.Entities.Tools;
using App.IoC.Repositories.Tools;
using Bogus;
using Moq;

namespace App.Test.App_Repository.Repositories;

public class ShortlinkRepositoryMock
{
  public IShortlinkRepository Mock { get; private set; }

  public ShortlinkRepositoryMock()
  {
    Mock<IShortlinkRepository> ShortlinkMock = new Mock<IShortlinkRepository>();

    Shortlink shortlink = new Faker<Shortlink>()
      .RuleFor(x => x.Id, 0)
      .RuleFor(x => x.Code, "ABC123")
      .RuleFor(x => x.Resume, f => f.Lorem.Text())
      .RuleFor(x => x.Link, f => f.Internet.Url())
      .Generate();

    ShortlinkMock.Setup(x => x.GetByCodeAsync(It.IsAny<string>(), CancellationToken.None)).ReturnsAsync(shortlink);
    ShortlinkMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), CancellationToken.None)).ReturnsAsync(shortlink);

    Mock = ShortlinkMock.Object;
  }
}
