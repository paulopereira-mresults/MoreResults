using Moq;

namespace App.Test.App_Repository.Repositories;

public abstract class AbstractMock<T> where T : class
{
  protected Mock<T> _mock = new Mock<T>();
  public T Generate() => _mock.Object;
  public T Object { get; private set; }

}
