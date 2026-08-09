using Avalonia.Media;

namespace MeowPaw.Terminal.Core;

public static class FontFamilyExtension
{
    /// <summary>
    /// 判断字体是否为等宽字体（monospace）。
    /// 通过比较一组代表性字符（窄字符 i、宽字符 W、数字 0/1、字母 m、空格）的字形 advance 宽度来判断：
    /// 若所有字符的 advance 宽度一致，则为等宽字体。
    /// </summary>
    public static bool IsMonospace(this FontFamily fontFamily)
    {
        if (!FontManager.Current.TryGetGlyphTypeface(new Typeface(fontFamily), out var glyphTypeface))
        {
            return false;
        }

        // 代表性测试字符：窄字符 'i'、宽字符 'W'、数字、字母、空格
        ReadOnlySpan<char> testChars = ['i', 'W', '0', '1', 'm', ' '];

        ushort? firstAdvance = null;
        var matchedCount = 0;
        foreach (var c in testChars)
        {
            var glyphId = glyphTypeface.CharacterToGlyphMap[c];
            if (glyphId == 0)
            {
                // glyph 0 是 notdef（字体缺该字符），跳过避免误判
                continue;
            }

            if (!glyphTypeface.TryGetHorizontalGlyphAdvance(glyphId, out var advance))
            {
                return false;
            }

            matchedCount++;
            if (firstAdvance is null)
            {
                firstAdvance = advance;
            }
            else if (advance != firstAdvance.Value)
            {
                return false;
            }
        }

        return matchedCount > 0;
    }
}
