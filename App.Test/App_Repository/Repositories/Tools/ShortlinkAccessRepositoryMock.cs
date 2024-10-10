using App.Domain.Entities.Tools;
using App.IoC.Repositories.Tools;
using Bogus;
using Moq;

namespace App.Test.App_Repository.Repositories.Tools;

public class ShortlinkAccessRepositoryMock : AbstractMock<IShortlinkAccessRepository>
{
    public ShortlinkAccessRepositoryMock WithCorrectlyAccess()
    {
        ShortlinkAccess shortlinkAccess = new Faker<ShortlinkAccess>()
          .RuleFor(x => x.Id, 1)
          .RuleFor(x => x.ShortlinkId, 1)
          .RuleFor(x => x.Ip, f => f.Internet.Ip())
          .Generate();

        _mock.Setup(x => x.AddAsync(It.IsAny<ShortlinkAccess>(), CancellationToken.None).Result).Returns(shortlinkAccess);

        return this;
    }

    public ShortlinkAccessRepositoryMock WithCorrectlyAddedAccess()
    {
        _mock.Setup(x => x.AddAsync(It.IsAny<ShortlinkAccess>(), CancellationToken.None).Result).Returns(new ShortlinkAccess { Id = 10 });

        return this;
    }
}
