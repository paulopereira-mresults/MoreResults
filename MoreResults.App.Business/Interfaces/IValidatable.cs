namespace MoreResults.App.Business.Interfaces;

public interface IValidatable<T>
{
    void Validate(T obj);
}
