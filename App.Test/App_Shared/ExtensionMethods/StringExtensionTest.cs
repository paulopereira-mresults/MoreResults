using App.Shared.ExtensionMethods;
using FluentAssertions;

namespace App.Test.App_Shared.ExtensionMethods;

public class StringExtensionTest
{
  [Fact]
  public void IsNullOrEmpty__Espera_que_o_metodo_retorne_verdadeiro_se_a_string_for_vazia()
  {
    // arrange
    string value = "";

    // act
    bool result = value.IsNullOrEmpty();

    // assert
    result
      .Should()
      .BeTrue();
  }

  [Fact]
  public void IsNullOrEmpty__Espera_que_o_metodo_retorne_verdadeiro_se_a_string_for_nula()
  {
    // arrange
    string? value = null;

    // act
    bool result = value.IsNullOrEmpty();

    // assert
    result
      .Should()
      .BeTrue();
  }

  [Fact]
  public void IsNotNullOrEmpty__Espera_que_o_metodo_retorne_falso_se_a_string_for_vazia()
  {
    // arrange
    string value = "teste de método";

    // act
    bool result = value.IsNotNullOrEmpty();

    // assert
    result
      .Should()
      .BeTrue();
  }

  [Fact]
  public void IsNullIfEmpty__Espera_quer_o_metodo_devolva_nulo_se_o_conteudo_da_string_for_vazio()
  {
    // arrange
    string? value = null;

    // act
    string? result = value?.IsNullIfEmpty();

    // assert
    result
      .Should()
      .BeNull();
  }

  [Theory]
  [InlineData("MD5", "7f138a09169b250e9dcb378140907378")]
  [InlineData("Gerando hash MD5", "b53235da27fdc724b7ef15f252de0271")]
  public void GetMd5__Espera_que_o_metodo_devolva_um_hash_md5_do_texto(string original, string expected)
  {
    // Arrange

    // Act
    string result = original.GetMd5();

    // Assert
    result
      .Should()
      .Be(expected);
  }

  [Theory]
  [InlineData("20", 20)]
  [InlineData("30", 30)]
  public void ToInt32__Espera_que_o_metodo_converta_um_texto_para_um_inteiro(string original, int expected)
  {
    // Arrange

    // Act
    int result = original.ToInt32();

    // Assert
    result
      .Should().Be(expected);
  }

  [Theory]
  [InlineData("20,05", 20.05)]
  [InlineData("30,5", 30.5)]
  public void ToDecimal__Espera_que_o_metodo_converta_um_texto_para_um_decimal(string original, decimal expected)
  {
    // Arrange

    // Act
    decimal result = original.ToDecimal();

    // Assert
    result
      .Should().Be(expected);
  }

  [Theory]
  [InlineData("The Theory attribute is used    to define a parametrized  test    ", "The Theory attribute is used to define a parametrized test")]
  [InlineData(" Each   set   of input   values  is  treated  as    a separate test  case. ", "Each set of input values is treated as a separate test case.")]
  public void ControlSpaces__Espera_que_o_metodo_controle_os_espacos_de_um_texto(string original, string expected)
  {
    // Arrange

    // Act
    string result = original.ControlSpaces();

    // Assert
    result
      .Should()
      .Be(expected);
  }

  [Fact]
  public void ControlSpaces__Espera_que_o_metodo_devolva_uma_string_vazia_caso_o_parametro_seja_nulo()
  {
    // Arrange
    string? text = null;

    // Act
    string result = text.ControlSpaces();

    // Assert
    result
      .Should()
      .BeEmpty();
  }

  [Fact]
  public void ControlSpaces__Espera_que_o_metodo_devolva_uma_string_vazia_caso_o_parametro_seja_vazio()
  {
    // Arrange
    string? text = string.Empty;

    // Act
    string result = text.ControlSpaces();

    // Assert
    result
      .Should()
      .BeEmpty();
  }

  [Theory]
  [InlineData("more results", "MR")]
  [InlineData("Microsoft Visual Studio", "MVS")]
  public void CreateCodeBasedOnValue__Espera_que_o_metodo_crie_um_metodo_a_partir_das_iniciais_das_palavras_do_texto(string original, string expected)
  {
    // Arrange

    // Act
    string result = original.CreateCodeBasedOnValue();

    // Assert
    result
      .Should()
      .Be(expected);
  }

  [Theory]
  [InlineData("CONVERTER PARA BASE64", "Q09OVkVSVEVSIFBBUkEgQkFTRTY0")]
  [InlineData("Microsoft Visual Studio", "TWljcm9zb2Z0IFZpc3VhbCBTdHVkaW8=")]
  public void EncodeToBase64__Espera_que_o_metodo_converta_um_texto_para_base64(string original, string expected)
  {
    // Arrange

    // Act
    string result = original.EncodeToBase64();

    // Assert
    result
      .Should()
      .Be(expected);
  }

  [Theory]
  [InlineData("CONVERTER PARA BASE64", "Q09OVkVSVEVSIFBBUkEgQkFTRTY0")]
  [InlineData("Microsoft Visual Studio", "TWljcm9zb2Z0IFZpc3VhbCBTdHVkaW8=")]
  public void DecodeToFile__Espera_que_o_metodo_decodifique_de_base64_para_texto_legivel(string expected, string original)
  {
    // Arrange

    // Act
    string result = original.DecodeFromBase64();

    // Assert
    result
      .Should()
      .Be(expected);
  }

  [Theory]
  [InlineData("Q09OVkVSVEVSIFBBUkEgQkFTRTY0")]
  [InlineData("TWljcm9zb2Z0IFZpc3VhbCBTdHVkaW8=")]
  public void IsValidBase64__Espera_verdadeiro_por_um_codigo_base64_valido(string original)
  {
    // Arrange

    // Act
    bool result = original.IsValidBase64();

    // Assert
    result
      .Should()
      .BeTrue();
  }

  [Theory]
  [InlineData("fhfhlkqwjherklwehioHUIOGIBIGHKUIOUIHIJ====")]
  [InlineData("GJHJKFGkuygvbjhkvgkjt=")]
  public void IsValidBase64__Espera_falso_por_um_codigo_base64_invalido(string original)
  {
    // Arrange

    // Act
    bool result = original.IsValidBase64();

    // Assert
    result
      .Should()
      .BeFalse();
  }

  [Theory]
  [InlineData("cb0193fc-d9e5-433a-80c5-be9d3361f531")]
  [InlineData("7fb73f4a-a76c-4cf1-9911-7cb715fa82c8")]
  public void IsValidGuid__Espera_verdadeiro_para_o_caso_do_conteudo_da_string_ser_um_Guid_valido(string original)
  {
    // Arrange

    // Act
    bool result = original.IsValidGuid();

    // Assert
    result
      .Should()
      .BeTrue();
  }

  [Theory]
  [InlineData("cb0193fc-d9e5-433a-80c5-dd4a4a1sd4s1a12ds3a")]
  [InlineData("7fb73f4a-a76c-4cf1-9911-7cb715fad4aadsafds21d1a")]
  public void IsValidGuid__Espera_falso_para_o_caso_do_conteudo_da_string_ser_um_Guid_invalido(string original)
  {
    // Arrange

    // Act
    bool result = original.IsValidGuid();

    // Assert
    result
      .Should()
      .BeFalse();
  }

  [Theory]
  [InlineData("Visual Studio", "Visual Stu", 10)]
  [InlineData("Microsoft Visual Studio", "Microsoft Visual Stu", 20)]
  public void Truncate__Espera_que_o_texto_seja_truncado_conforme_a_medida_informada(string original, string expected, int maxLength)
  {
    // Arrange

    // Act
    string result = original.Truncate(maxLength);

    // Assert
    result
      .Should()
      .Be(expected);
  }

  [Theory]
  [InlineData("Eu tenho 41 anos e nasci no dia 23/04/1983", "4123041983")]
  [InlineData("A linguagem C# nasceu no ano de 2000", "2000")]
  public void OnlyNumbers__Espera_que_o_metodo_retorne_somente_os_numeros_do_texto(string original, string expected)
  {
    // Arrange

    // Act
    string result = original.OnlyNumbers();

    // Assert
    result
      .Should()
      .Be(expected);
  }

  [Theory]
  [InlineData("Eu tenho 41 anos e nasci no dia 23/04/1983", "4123041983", "ABC")]
  [InlineData("A linguagem C# nasceu no ano de 2000", "2000", "DFG")]
  public void OnlyNumbers__Espera_que_o_metodo_retorne_somente_os_numeros_do_texto_com_um_prefixo_na_frente(string original, string expected, string prefix)
  {
    // Arrange

    // Act
    string result = original.OnlyNumbers(prefix);

    // Assert
    result
      .Should()
      .Be(prefix + expected);
  }
}
