namespace App.Services.Logs;

public class LogHelper
{
  public static async Task WriteAsync(string endpoint, string method, int responseCode, string connectionId)
  {
    try
    {
      DateTime today = DateTime.Now;
      string directory = "C:\\Users\\MoreResults\\Documents\\Projetos";
      string filename = Path.Combine(directory, $"log_{today:yyyy-MM-dd}.txt");
      string content = $"{today:s};{endpoint};{method};{responseCode};{connectionId}";

      // Verifique se o diretório existe
      if (!Directory.Exists(directory))
      {
        Console.WriteLine($"--- Diretório não encontrado: {directory}");
        Directory.CreateDirectory(directory);
        Console.WriteLine($"--- Diretório criado: {directory}");
      }

      if (File.Exists(filename))
      {
        // Abre o arquivo e adiciona a linha no final
        using (StreamWriter sw = File.AppendText(filename))
        {
          await sw.WriteLineAsync(content);
        }
      }
      else
      {
        // Adiciona nova linha ao final do conteúdo
        await File.WriteAllTextAsync(filename, content + Environment.NewLine);
      }
      Console.WriteLine($"--- Escrevendo log em {filename}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"--- Erro ao escrever log: {ex.Message}");
    }
  }
}
