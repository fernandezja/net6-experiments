// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Text;



Console.WriteLine("Hello, World!");






int i = 0;
int totalV = 0;
int totalC = 0;
string vocales = "aeiou";
string letra = string.Empty;
string num = "1234567890";

Console.Write("Ingrese una frase: ");
var fraseOriginal = "aarónúü";
var frase = fraseOriginal.RemoveAccents();

Console.Write($"    |_ Original: {fraseOriginal}");
Console.Write($"    |_ Original: {frase}");
while (i < frase.Length)
{
    letra = frase.Substring(i, 1).ToLower();
    if (vocales.Contains(letra))
        totalV++;
    else if (letra != " " && !num.Contains(letra))
        totalC++;

    i++;
}
Console.WriteLine("La frase {0} tiene {1} vocales y {2} consonantes", frase, totalV, totalC);

public static class Util
{
    public static string RemoveAccents(this string textInput)
    {
        if (string.IsNullOrEmpty(textInput))
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        
        var arrayText = textInput.Normalize(NormalizationForm.FormD).ToCharArray();

        foreach (char letter in arrayText)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                sb.Append(letter);
        }
        return sb.ToString();
    }

}

