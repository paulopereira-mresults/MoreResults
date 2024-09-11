using App.IoC;
using System.Reflection;

namespace App.Services.Plugins;

public class PluginExecution
{
    private readonly IExternalPlugin plugin;
    private readonly string _baseDirectory;
    private object? loadedPlugin { get; set; } = null;

    public PluginExecution(string baseDirectory)
    {
        _baseDirectory = baseDirectory;
    }

    public void ExecuteAfter(string name, object? parameter) => Execute(name, "ExecuteAfter", parameter);
    
    public void ExecuteBefore(string name, object? parameter) => Execute(name, "ExecuteBefore", parameter);


    private void Execute(string pluginName, string methodName, object? parameter)
    {
        pluginName = pluginName.Replace("Controller", string.Empty);
        string filename = Path.Combine(_baseDirectory, $@"{pluginName}Plugin.dll");

        Console.WriteLine($"Localizando plugin em {filename}");

        object[] parameters = parameter is null? new object[0] : new object[] { parameter };

        if (File.Exists(filename))
        {
            Console.WriteLine("Plugin localizado.");

            try
            {
                var DLL = Assembly.LoadFile(filename);

                var theType = DLL.GetType($@"{pluginName}Plugin.{pluginName}");
                var instanceOfPlugin = Activator.CreateInstance(theType);
                var method = theType.GetMethod(methodName);
                method.Invoke(instanceOfPlugin, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao executar o plugin: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Plugin não localizado");
        }
    }


}
