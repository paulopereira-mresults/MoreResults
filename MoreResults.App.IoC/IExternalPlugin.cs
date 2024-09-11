namespace MoreResults.App.IoC;

public interface IExternalPlugin
{
    string Name { get; }
    void Execute();
}
