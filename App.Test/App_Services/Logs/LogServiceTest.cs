using App.Services.Logs;
using FluentAssertions;
using System.Net;

namespace App.Test.App_Services.Logs;

public class LogServiceTest
{
  [Theory]
  [InlineData("startup", "GET", 200, "ABC123")]
  public async Task WriteAsync__Espera_que_o_arquivo_de_log_seja_escrito_no_local_correto (string endpoint, string method, int responseCode, string connectionId)
  {
    // Arrange
    string directory = LogService.GetDirectory();
    string filename = LogService.GetFilename();
    string fullpath = Path.Combine(directory, filename);

    // Act
    await LogService.WriteAsync(endpoint, method, responseCode, connectionId);
    bool fileExists = File.Exists(fullpath);
    
    // Assert
    fileExists
      .Should().BeTrue();

    //File.Delete(fullpath);
  }

  [Theory]
  [InlineData("startup", "GET", 200, "ABC123")]
  public async Task WriteAsync__Espera_que_o_arquivo_de_log_contenha_os_dados_conforme_padrao_estabelecido(string endpoint, string method, int responseCode, string connectionId)
  {
    // Arrange
    string directory = LogService.GetDirectory();
    string filename = LogService.GetFilename();
    string fullpath = Path.Combine(directory, filename);
    DateTime today = DateTime.Now;
    string expectedLine = $"{today:s};{endpoint};{method};{responseCode};{connectionId}";

    // Act
    await LogService.WriteAsync(endpoint, method, responseCode, connectionId);
    string fileContents = await File.ReadAllTextAsync(fullpath);

    // Assert
    fileContents
      .Should()
      .Contain(expectedLine);

    File.Delete(fullpath);
  }
}
