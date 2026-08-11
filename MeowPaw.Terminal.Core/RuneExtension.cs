using System.Text;

namespace MeowPaw.Terminal.Core;

public static class RuneExtension
{
    public static char[] EncodeToCharArray(this Rune rune)
    {
        Span<char> span = stackalloc char[2];
        var written = rune.EncodeToUtf16(span);

        var result = new char[written];
        for (int i = 0; i < written; i++)
        {
            result[i] = span[i];
        }

        return result;
    }

    public static bool IsNormalChar(this Rune rune)
    {
        Span<char> span = stackalloc char[2];
        return rune.EncodeToUtf16(span) is 1;
    }
}