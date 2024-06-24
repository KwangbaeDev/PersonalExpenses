using System.Globalization;
using System.Text;

namespace Core.Helpers;

public static class StringExtensions
{
public static string NoAccent(this string texto) =>
    new string(texto.Normalize(NormalizationForm.FormD)
        .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
        .ToArray())
    .Normalize(NormalizationForm.FormC);
}