using Humanizer;

namespace CatchUpPlatform.API.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

public static class StringExtension
{
    public static string ToSnakeCase(this string text)
    {
        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if(!e.MoveNext())
                yield break;
            yield return char.ToLower(e.Current);
            while (e.MoveNext())
            {
                if (char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
            }
        }
        return ToSnakeCase(text).ToString();
    }
    public static string ToPlural(this string text)
    {

        return text.Pluralize(false);
    }
}