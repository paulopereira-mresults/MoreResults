using App.Domain.Entities.Tools;
using App.IoC.Repositories.Tools;
using Bogus;
using Moq;

namespace App.Test.App_Repository.Repositories;

public class ShortlinkRepositoryMock: AbstractMock<IShortlinkRepository>
{
  public ShortlinkRepositoryMock()
  {
    IEnumerable<Shortlink> shortlinks = new Faker<Shortlink>()
      .RuleFor(x => x.Id, 0)
      .RuleFor(x => x.Code, f => f.Random.AlphaNumeric(5))
      .RuleFor(x => x.Resume, f => f.Lorem.Text())
      .RuleFor(x => x.Link, f => f.Internet.Url())
      .Generate(10);

    _mock.Setup(x => x.ListAsync(CancellationToken.None)).ReturnsAsync(shortlinks);
  }

  public ShortlinkRepositoryMock WithCorrectlyLink()
  {
    Shortlink shortlink = new Faker<Shortlink>()
      .RuleFor(x => x.Id, 0)
      .RuleFor(x => x.Code, "ABC123")
      .RuleFor(x => x.Resume, f => f.Lorem.Text())
      .RuleFor(x => x.Link, f => f.Internet.Url())
      .Generate();

    _mock.Setup(x => x.GetByCodeAsync(It.IsAny<string>(), CancellationToken.None)).ReturnsAsync(shortlink);
    _mock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), CancellationToken.None)).ReturnsAsync(shortlink);

    return this;
  }

  public ShortlinkRepositoryMock WithCorrectlyLinks()
  {
    Shortlink shortlink = new Faker<Shortlink>()
     .RuleFor(x => x.Id, 0)
     .RuleFor(x => x.Code, "ABC123")
     .RuleFor(x => x.Resume, f => f.Lorem.Text())
     .RuleFor(x => x.Link, f => f.Internet.Url())
     .Generate();

    return this;
  }

  public ShortlinkRepositoryMock WithNullableLink()
  {
    Shortlink? shortlink = null;

    _mock.Setup(x => x.GetByCodeAsync(It.IsAny<string>(), CancellationToken.None)).ReturnsAsync(shortlink);
    _mock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), CancellationToken.None)).ReturnsAsync(shortlink);

    return this;
  }

  public ShortlinkRepositoryMock WithCorrectlyAddedLink(Shortlink link)
  {
    _mock.Setup(x => x.AddAsync(It.IsAny<Shortlink>(), CancellationToken.None)).ReturnsAsync(link);
    return this;
  }

  public ShortlinkRepositoryMock WithCorrectlyUpdatedLink(Shortlink link)
  {
    _mock.Setup(x => x.UpdateAsync(It.IsAny<Shortlink>(), CancellationToken.None)).ReturnsAsync(link);
    return this;
  }

  public ShortlinkRepositoryMock WithCorrectlyDeletedLink()
  {
    Shortlink? shortlink = null;
    _mock.Setup(x => x.DeleteAsync(It.IsAny<Shortlink>(), CancellationToken.None)).ReturnsAsync(true);
    return this;
  }

  public ShortlinkRepositoryMock WithFailOnDeletedLink()
  {
    Shortlink? shortlink = null;
    _mock.Setup(x => x.DeleteAsync(It.IsAny<Shortlink>(), CancellationToken.None)).ReturnsAsync(false);
    return this;
  }

}
