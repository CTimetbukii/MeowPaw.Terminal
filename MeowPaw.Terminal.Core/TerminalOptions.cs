using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace MeowPaw.Terminal.Core;

/// <summary>
/// 终端渲染选项。由 <see cref="Terminal"/> 的属性变化时同步而来，作为只读快照传给 <see cref="Render.Renderer"/> 使用。
/// </summary>
public class TerminalOptions
{
    #region Appearance

    private FontFamily _fontFamily = FontFamily.Default;

    /// <summary>
    /// 字体。变化时自动重建 <see cref="Typeface"/>
    /// </summary>
    public FontFamily FontFamily
    {
        get => _fontFamily;
        set
        {
            _fontFamily = value;
            UpdateTypeface();
        }
    }

    public double FontSize { get; set; } = 12;
    public double LineHeightTimes { get; set; } = 1.2;

    private FontStyle _fontStyle = FontStyle.Normal;

    /// <summary>
    /// 字体样式。变化时自动重建 <see cref="Typeface"/>
    /// </summary>
    public FontStyle FontStyle
    {
        get => _fontStyle;
        set
        {
            _fontStyle = value;
            UpdateTypeface();
        }
    }

    private FontStretch _fontStretch = FontStretch.Normal;

    /// <summary>
    /// 字体拉伸。变化时自动重建 <see cref="Typeface"/>
    /// </summary>
    public FontStretch FontStretch
    {
        get => _fontStretch;
        set
        {
            _fontStretch = value;
            UpdateTypeface();
        }
    }

    private FontWeight _fontWeight = FontWeight.Normal;

    public FontWeight FontWeight
    {
        get => _fontWeight;
        set
        {
            _fontWeight = value;
            UpdateTypeface();
        }
    }

    /// <summary>
    /// 由 <see cref="FontFamily"/>、<see cref="FontStyle"/>、<see cref="FontStretch"/> 组合而成的 Typeface。
    /// 任一属性变化时自动更新，供渲染直接使用
    /// </summary>
    public Typeface Typeface { get; private set; }

    public bool EnableFullColorEmoji { get; set; } = true;
    public bool EnableAdjustUnrecognizableTextBright { get; set; } = true;
    public CursorType CursorType { get; set; } = MeowPaw.Terminal.Core.CursorType.Strip;
    public IBrush CursorBrush { get; set; } = Brushes.White;
    public IImage? BackgroundImage { get; set; }
    public BackgroundImageStretch BackgroundImageStretch { get; set; } = MeowPaw.Terminal.Core.BackgroundImageStretch.UniformToFill;
    public BackgroundImageAlign BackgroundImageAlign { get; set; } = MeowPaw.Terminal.Core.BackgroundImageAlign.Center;
    public double BackgroundImageOpacity { get; set; } = 1.0;
    public EmphasizeTextStyle EmphasizeTextStyle { get; set; } = MeowPaw.Terminal.Core.EmphasizeTextStyle.Highlight;
    public double BackgroundBrushOpacity { get; set; } = 1.0;
    public Thickness Padding { get; set; } = new(8, 8, 8, 8);
    public ScrollbarVisibility ScrollbarVisibility { get; set; } = MeowPaw.Terminal.Core.ScrollbarVisibility.Auto;
    public IBrush ForegroundBrush { get; set; } = Brushes.White;

    /// <summary>
    /// 终端背景画笔
    /// </summary>
    public IBrush BackgroundBrush { get; set; } = Brushes.Black;

    /// <summary>
    /// 渲染区域（本地坐标，即 (0,0,宽,高)）。由 <see cref="Terminal"/> 布局时同步
    /// </summary>
    public Rect Bounds { get; set; }

    #endregion

    #region Terminal Emulate

    public bool DenyChangeTitle { get; set; }
    public bool AllowDECRQCRA { get; set; }
    public bool AllowOSC52WriteClipboard { get; set; } = true;
    public byte[]? ENQResponse { get; set; }

    #endregion

    #region Advanced

    public bool ScrollToInputPosition { get; set; } = true;
    public int HistoryLineSize { get; set; } = 9999;
    public BELBehavior BELBehavior { get; set; } = MeowPaw.Terminal.Core.BELBehavior.Voice;
    public bool ShowRightClickMenu { get; set; }

    #endregion

    public TerminalOptions()
    {
        // 兜底：无论字段声明顺序如何，确保 Typeface 有正确的初始值
        UpdateTypeface();
    }

    private void UpdateTypeface()
    {
        Typeface = new Typeface(_fontFamily, _fontStyle, _fontWeight, _fontStretch);
    }
}
