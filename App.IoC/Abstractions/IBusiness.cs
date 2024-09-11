namespace App.IoC.Abstractions;

public interface IBusiness
{
    IRepositories Repositories { get; }
}
