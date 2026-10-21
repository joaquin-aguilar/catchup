using System.Text.RegularExpressions;

namespace CatchUpPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static partial class StringExtensions
{
    [GeneratedRegex("^[a-z]+(-[a-z]+)*$", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();

    public static string ToKebabCase(this string text)
    {
        if(string.IsNullOrEmpty(text))
            return text;
        return KebabCaseRegex().Replace(text, "-$1").Trim().ToLower();
    }
}