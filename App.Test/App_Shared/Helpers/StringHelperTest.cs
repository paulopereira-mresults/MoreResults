using App.Shared.Helpers;
using FluentAssertions;

namespace App.Test.App_Shared.Helpers;

public class StringHelperTest
{
  [Fact]
  public void GenerateRandomCode__Espera_que_o_metodo_gera_um_codigo_com_quatro_caracteres()
  {
    // Arrange
    int length = 4;
    string characters = "ABCDEFGHIJLMNOPQRSTUVXZKWY0123456789";

    // Act
    string code = StringHelper.GenerateRandomCode(length, characters);

    // Assert
    code
      .Length
      .Should()
      .Be(4);
  }

  [Fact]
  public void GenerateRandomCode__Espera_excessao_por_caracteres_vazio()
  {
    // Arrange
    int length = 4;
    string characters = "";
    Action act = () => StringHelper.GenerateRandomCode(length, characters);

    // Act
    ArgumentException result = Assert.Throws<ArgumentException>(act);

    // Assert
    result
      .Should()
      .NotBeNull();

    result
      .Message
      .Should()
      .NotBeNull()
      .And
      .Be("A string de caracteres não pode ser nula ou vazia.");
  }

  [Fact]
  public void GenerateRandomCode__Espera_excessao_por_tamanho_codigo_ser_menor_que_zero()
  {
    // Arrange
    int length = 0;
    string characters = "ABCDEFGHIJLMNOPQRSTUVXZKWY0123456789";
    Action act = () => StringHelper.GenerateRandomCode(length, characters);

    // Act
    ArgumentException result = Assert.Throws<ArgumentException>(act);

    // Assert
    result
      .Should()
      .NotBeNull();

    result
      .Message
      .Should()
      .NotBeNull()
      .And
      .Be("O comprimento do código deve ser um número positivo.");
  }
}
