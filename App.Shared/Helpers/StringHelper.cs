namespace App.Shared.Helpers;

public class StringHelper
{
    /// <summary>
    /// Gera um código aleatório a partir de uma string fornecida.
    /// </summary>
    public static string GenerateRandomCode(int length = 4, string characters = "ABCDEFGHIJLMNOPQRSTUVXZKWY0123456789")
    {
        if (string.IsNullOrEmpty(characters))
        {
            throw new ArgumentException("A string de caracteres não pode ser nula ou vazia.", nameof(characters));
        }

        if (length <= 0)
        {
            throw new ArgumentException("O comprimento do código deve ser um número positivo.", nameof(length));
        }

        Random random = new Random();
        char[] code = new char[length];

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(characters.Length);
            code[i] = characters[index];
        }

        return new string(code);
    }
}
