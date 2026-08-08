using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace MeowPaw.Terminal.Core;

public class Terminal : Control
{
    #region Appearance Properties
    
    public static readonly StyledProperty<FontFamily> FontProperty = AvaloniaProperty.Register<Terminal, FontFamily>(
        nameof(FontFamily), defaultValue: FontFamily.Default);

    public static readonly StyledProperty<double> FontSizeProperty = AvaloniaProperty.Register<Terminal, double>(
        nameof(FontSize), defaultValue: 12);

    public static readonly StyledProperty<double> LineHeightTimesProperty = AvaloniaProperty.Register<Terminal, double>(
        nameof(LineHeightTimes), defaultValue: 1.2);

    public static readonly StyledProperty<double> CellWidthTimesProperty = AvaloniaProperty.Register<Terminal, double>(
        nameof(CellWidthTimes), defaultValue: 1.05);

    public static readonly StyledProperty<FontStyle> FontStyleProperty = AvaloniaProperty.Register<Terminal, FontStyle>(
        nameof(FontStyle), defaultValue:FontStyle.Normal);

    public static readonly StyledProperty<FontStretch> FontStretchProperty = AvaloniaProperty.Register<Terminal, FontStretch>(
        nameof(FontStretch), defaultValue:FontStretch.Normal);

    public static readonly StyledProperty<bool> EnableFullColorEmojProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(EnableFullColorEmoji), defaultValue:true);

    public static readonly StyledProperty<bool> AdjustUnrecognizableTextBrightProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(EnableAdjustUnrecognizableTextBright), defaultValue:true);

    public static readonly StyledProperty<CursorType> CurorTypeProperty = AvaloniaProperty.Register<Terminal, CursorType>(
        nameof(CursorType), defaultValue: CursorType.Strip);

    public static readonly StyledProperty<IBrush> CursorBrushProperty = AvaloniaProperty.Register<Terminal, IBrush>(
        nameof(CursorBrush), defaultValue: Brushes.White);

    public static readonly StyledProperty<Image?> BackgroundImageProperty = AvaloniaProperty.Register<Terminal, Image?>(
        nameof(BackgroundImage), defaultValue:null);

    public static readonly StyledProperty<BackgroundImageStretch> BackgroundImageStretchProperty = AvaloniaProperty.Register<Terminal, BackgroundImageStretch>(
        nameof(BackgroundImageStretch), defaultValue:BackgroundImageStretch.UniformToFill);

    public static readonly StyledProperty<BackgroundImageAlign> BackgroundImageAlignProperty = AvaloniaProperty.Register<Terminal, BackgroundImageAlign>(
        nameof(BackgroundImageAlign), defaultValue:BackgroundImageAlign.Center);

    public static readonly StyledProperty<double> BackgroundImageOpacityProperty = AvaloniaProperty.Register<Terminal, double>(
        nameof(BackgroundImageOpacity), defaultValue:1.0);

    public static readonly StyledProperty<EmphasizeTextStyle> EmphasizeTextStyleProperty = AvaloniaProperty.Register<Terminal, EmphasizeTextStyle>(
        nameof(EmphasizeTextStyle), defaultValue: EmphasizeTextStyle.Highlight);

    public static readonly StyledProperty<double> BackgroundOpacityProperty = AvaloniaProperty.Register<Terminal, double>(
        nameof(BackgroundOpacity), defaultValue:1.0);

    public static readonly StyledProperty<Thickness> PaddingProperty = AvaloniaProperty.Register<Terminal, Thickness>(
        nameof(Padding), defaultValue:new Thickness(8, 8, 8, 8));

    public static readonly StyledProperty<ScrollbarVisibility> ScrollbarVisibilityProperty = AvaloniaProperty.Register<Terminal, ScrollbarVisibility>(
        nameof(ScrollbarVisibility), defaultValue:ScrollbarVisibility.Auto);

    public ScrollbarVisibility ScrollbarVisibility
    {
        get => GetValue(ScrollbarVisibilityProperty);
        set => SetValue(ScrollbarVisibilityProperty, value);
    }

    public Thickness Padding
    {
        get => GetValue(PaddingProperty);
        set => SetValue(PaddingProperty, value);
    }

    public double BackgroundOpacity
    {
        get => GetValue(BackgroundOpacityProperty);
        set => SetValue(BackgroundOpacityProperty, value);
    }

    public EmphasizeTextStyle EmphasizeTextStyle
    {
        get => GetValue(EmphasizeTextStyleProperty);
        set => SetValue(EmphasizeTextStyleProperty, value);
    }

    public double BackgroundImageOpacity
    {
        get => GetValue(BackgroundImageOpacityProperty);
        set => SetValue(BackgroundImageOpacityProperty, value);
    }

    public BackgroundImageAlign BackgroundImageAlign
    {
        get => GetValue(BackgroundImageAlignProperty);
        set => SetValue(BackgroundImageAlignProperty, value);
    }

    public BackgroundImageStretch BackgroundImageStretch
    {
        get => GetValue(BackgroundImageStretchProperty);
        set => SetValue(BackgroundImageStretchProperty, value);
    }

    public Image? BackgroundImage
    {
        get => GetValue(BackgroundImageProperty);
        set => SetValue(BackgroundImageProperty, value);
    }

    public IBrush CursorBrush
    {
        get => GetValue(CursorBrushProperty);
        set => SetValue(CursorBrushProperty, value);
    }

    public CursorType CursorType
    {
        get => GetValue(CurorTypeProperty);
        set => SetValue(CurorTypeProperty, value);
    }

    /// <summary>
    /// 自动调整无法区分的文本的亮度。启用后，将自动使文本变亮或变暗，以使其更可见。即使启用后，仅当前景色和背景色的组合导致对比度较差时，才会进行此调整
    /// </summary>
    public bool EnableAdjustUnrecognizableTextBright
    {
        get => GetValue(AdjustUnrecognizableTextBrightProperty);
        set => SetValue(AdjustUnrecognizableTextBrightProperty, value);
    }

    /// <summary>
    /// 全色表情符号，启用后，表情符号将以全色显示。默认启用
    /// </summary>
    public bool EnableFullColorEmoji
    {
        get => GetValue(EnableFullColorEmojProperty);
        set => SetValue(EnableFullColorEmojProperty, value);
    }

    public FontStretch FontStretch
    {
        get => GetValue(FontStretchProperty);
        set => SetValue(FontStretchProperty, value);
    }

    public FontStyle FontStyle
    {
        get => GetValue(FontStyleProperty);
        set => SetValue(FontStyleProperty, value);
    }

    public double CellWidthTimes
    {
        get => GetValue(CellWidthTimesProperty);
        set => SetValue(CellWidthTimesProperty, value);
    }

    public double LineHeightTimes
    {
        get => GetValue(LineHeightTimesProperty);
        set => SetValue(LineHeightTimesProperty, value);
    }

    public double FontSize
    {
        get => GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public FontFamily FontFamily
    {
        get => GetValue(FontProperty);
        set => SetValue(FontProperty, value);
    }

    #endregion

    #region Terminal Emulate Properties

    public static readonly StyledProperty<bool> DenyChangeTitleProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(DenyChangeTitle), defaultValue:false);

    public static readonly StyledProperty<bool> AllowDECRQCRAProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(AllowDECRQCRA), defaultValue:false);

    public static readonly StyledProperty<bool> AllowOSC52WriteClipboardProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(AllowOSC52WriteClipboard), defaultValue:true);

    public static readonly StyledProperty<byte[]?> ENQResponseProperty = AvaloniaProperty.Register<Terminal, byte[]?>(
        nameof(ENQResponse), defaultValue:null);

    public byte[]? ENQResponse
    {
        get => GetValue(ENQResponseProperty);
        set => SetValue(ENQResponseProperty, value);
    }

    /// <summary>
    /// 允许 OSC 52 (Manipulate Selection Data) 写入剪贴板
    /// </summary>
    public bool AllowOSC52WriteClipboard
    {
        get => GetValue(AllowOSC52WriteClipboardProperty);
        set => SetValue(AllowOSC52WriteClipboardProperty, value);
    }

    /// <summary>
    /// 允许 DECRQCRA (Request Checksum of Rectangular Area)
    /// </summary>
    public bool AllowDECRQCRA
    {
        get => GetValue(AllowDECRQCRAProperty);
        set => SetValue(AllowDECRQCRAProperty, value);
    }

    public bool DenyChangeTitle
    {
        get => GetValue(DenyChangeTitleProperty);
        set => SetValue(DenyChangeTitleProperty, value);
    }

    #endregion

    #region Advanced

    public static readonly StyledProperty<bool> ScrollToInputPositionProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(ScrollToInputPosition), defaultValue:true);

    public static readonly StyledProperty<int> HistorySizeProperty = AvaloniaProperty.Register<Terminal, int>(
        nameof(HistoryLineSize), defaultValue:9999);

    // ReSharper disable once InconsistentNaming
    public static readonly StyledProperty<BELBehavior> BELBehaviorProperty = AvaloniaProperty.Register<Terminal, BELBehavior>(
        nameof(BELBehavior), defaultValue:BELBehavior.Voice);

    public static readonly StyledProperty<bool> ShowRightClickMenuProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(ShowRightClickMenu), defaultValue:false);

    /// <summary>
    /// 启用后，将在右键时显示菜单。禁用后，右键单击将复制所选的文本，如果没有所选的文本，则粘贴剪贴板中的内容。默认禁用
    /// </summary>
    public bool ShowRightClickMenu
    {
        get => GetValue(ShowRightClickMenuProperty);
        set => SetValue(ShowRightClickMenuProperty, value);
    }

    /// <summary>
    /// 当应用程序发出BEL字符时执行的操作
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public BELBehavior BELBehavior
    {
        get => GetValue(BELBehaviorProperty);
        set => SetValue(BELBehaviorProperty, value);
    }

    public int HistoryLineSize
    {
        get => GetValue(HistorySizeProperty);
        set => SetValue(HistorySizeProperty, value);
    }

    /// <summary>
    /// 当输入时滚动到输入位置
    /// </summary>
    public bool ScrollToInputPosition
    {
        get => GetValue(ScrollToInputPositionProperty);
        set => SetValue(ScrollToInputPositionProperty, value);
    }

    #endregion

    public Terminal()
    {
        AffectsRender<Terminal>(
            FontProperty,
            FontSizeProperty,
            LineHeightTimesProperty,
            CellWidthTimesProperty,
            FontStyleProperty,
            FontStretchProperty,
            EnableFullColorEmojProperty,
            AdjustUnrecognizableTextBrightProperty,
            CurorTypeProperty,
            CursorBrushProperty,
            BackgroundImageProperty,
            BackgroundImageStretchProperty,
            BackgroundImageAlignProperty,
            BackgroundImageOpacityProperty,
            EmphasizeTextStyleProperty,
            BackgroundOpacityProperty,
            PaddingProperty,
            ScrollbarVisibilityProperty,
            HistorySizeProperty);
    }
    
    public override void Render(DrawingContext context)
    {
        
    }
}