using Avalonia;
using Avalonia.Media;

namespace MeowPaw.Terminal.Core;

public class Renderer
{
    public void Render(DrawingContext context, TerminalOptions options)
    {
        RenderBackgroundBrush(context, options);
        RenderBackgroundImage(context, options);
        RenderText(context, options);
        RenderCursor(context, options);
    }

    private void RenderCursor(DrawingContext context, TerminalOptions options)
    {
        
    }

    private void RenderText(DrawingContext context, TerminalOptions options)
    {
        
    }

    private void RenderBackgroundBrush(DrawingContext context, TerminalOptions options)
    {
        var bounds = options.Bounds;
        if (bounds.Width <= 0 || bounds.Height <= 0)
        {
            return;
        }

        using (context.PushOpacity(options.BackgroundBrushOpacity))
        {
            context.DrawRectangle(options.BackgroundBrush, new Pen(), bounds);
        }
    }
    
    private void RenderBackgroundImage(DrawingContext context, TerminalOptions options)
    {
        var bounds = options.Bounds;
        if (bounds.Width <= 0 || bounds.Height <= 0)
        {
            return;
        }

        if (options.BackgroundImage is not { } image)
        {
            return;
        }

        var source = new Rect(0, 0, image.Size.Width, image.Size.Height);
        var dest = ComputeImageDestRect(image, bounds, options.BackgroundImageStretch, options.BackgroundImageAlign);
        if (dest.Width <= 0 || dest.Height <= 0)
        {
            return;
        }

        // 裁剪到渲染区域（UniformToFill / None 可能超出 bounds），并应用图片透明度
        using (context.PushClip(bounds))
        using (context.PushOpacity(options.BackgroundImageOpacity))
        {
            context.DrawImage(image, source, dest);
        }
    }

    // 按 Stretch 计算图片目标矩形，并按 Align 在 bounds 内对齐
    private Rect ComputeImageDestRect(IImage image, Rect bounds, BackgroundImageStretch stretch, BackgroundImageAlign align)
    {
        var sourceW = image.Size.Width;
        var sourceH = image.Size.Height;
        if (sourceW <= 0 || sourceH <= 0)
        {
            return default;
        }

        double destW, destH;
        switch (stretch)
        {
            case BackgroundImageStretch.None:
                // 原尺寸绘制，不缩放
                destW = sourceW;
                destH = sourceH;
                break;
            case BackgroundImageStretch.Fill:
                // 拉伸填满，宽高各自缩放（可能变形）
                destW = bounds.Width;
                destH = bounds.Height;
                break;
            case BackgroundImageStretch.Uniform:
            {
                // 等比缩放完整显示（letterbox，留白）
                var scale = Math.Min(bounds.Width / sourceW, bounds.Height / sourceH);
                destW = sourceW * scale;
                destH = sourceH * scale;
                break;
            }
            case BackgroundImageStretch.UniformToFill:
            default:
            {
                // 等比缩放填满，超出部分裁剪
                var scale = Math.Max(bounds.Width / sourceW, bounds.Height / sourceH);
                destW = sourceW * scale;
                destH = sourceH * scale;
                break;
            }
        }

        var x = align switch
        {
            BackgroundImageAlign.TopLeft or BackgroundImageAlign.Left or BackgroundImageAlign.BottomLeft => bounds.X,
            BackgroundImageAlign.TopCenter or BackgroundImageAlign.Center or BackgroundImageAlign.BottomCenter => bounds.X + (bounds.Width - destW) / 2,
            _ => bounds.Right - destW,
        };
        var y = align switch
        {
            BackgroundImageAlign.TopLeft or BackgroundImageAlign.TopCenter or BackgroundImageAlign.TopRight => bounds.Y,
            BackgroundImageAlign.Left or BackgroundImageAlign.Center or BackgroundImageAlign.Right => bounds.Y + (bounds.Height - destH) / 2,
            _ => bounds.Bottom - destH,
        };

        return new Rect(x, y, destW, destH);
    }
}
