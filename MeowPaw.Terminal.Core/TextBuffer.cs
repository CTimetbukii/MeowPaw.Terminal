using System.Text;

namespace MeowPaw.Terminal.Core;

public class TextBuffer
{
    // // ReSharper disable once MemberCanBePrivate.Global
    // public RenderRow[] Rows { get; private set; }
    //
    // public int LogicalStartOffset { get; set; } = 0; //指向第一行
    //
    // // ReSharper disable once ConvertToPrimaryConstructor
    // public TextBuffer(int capacity)
    // {
    //     Rows = new RenderRow[capacity];
    // }
    //
    // private int ReflectRenderIndexToLogicIndex(int renderRowIndex)
    // {
    //     return renderRowIndex % Rows.Length + LogicalStartOffset;
    // }
    //
    // public RenderRow GetRenderRow(int renderRowIndex)
    // {
    //     return Rows[ReflectRenderIndexToLogicIndex(renderRowIndex)];
    // }
    //
    // public void AdjustCapacity(int newCapacity)
    // {
    //     var temp = Rows;
    //
    //     if (newCapacity == temp.Length)
    //     {
    //         return;
    //     }
    //     
    //     Rows = new RenderRow[newCapacity];
    //
    //     if (newCapacity > temp.Length)
    //     {
    //         //把原有内容原封不动的copy进去
    //         Array.Copy(temp, Rows, temp.Length);
    //     }
    //     else
    //     {
    //         //采取从数组最底部向前复制的算法。
    //         
    //     }
    // }
    //
    // public void Write(Rune rune, int renderRowIndex)
    // {
    //     var remaining = GetRenderRow(renderRowIndex).GetRemainCount();
    //     if (remaining > 1)
    //     {
    //         Write(rune.EncodeToCharArray(), renderRowIndex);
    //     }
    //     else if (remaining is 1)
    //     {
    //         if (rune.IsNormalChar())
    //         {
    //             Write(rune.EncodeToCharArray(), renderRowIndex);
    //         }
    //         else
    //         {
    //             GetRenderRow(renderRowIndex).ClearCursor(); //光标已经移动到下一行，所以把上一行的光标清空
    //             Write(rune.EncodeToCharArray(), renderRowIndex + 1);
    //         }
    //     }
    //     else
    //     {
    //         throw new InvalidOperationException("Out of index: Application is trying to write a Rune into a full Row.");
    //     }
    // }
    //
    // private void Write(char[] cs, int renderRowIndex)
    // {
    //     foreach (var c in cs)
    //     {
    //         Write(c, renderRowIndex);
    //     }
    // }
    //
    // private void Write(char c, int renderRowIndex)
    // {
    //     //到了这里了Remaining肯定是大于1的，不用再检查
    //     GetRenderRow(renderRowIndex).Write(c);
    // }
    //
    // public void Backspace(int renderRowIndex)
    // {
    //     var row = GetRenderRow(renderRowIndex);
    //     row.CursorIndex--;
    //     row.Replace(row.CursorIndex, '\0');
    // }
    //
    // public void Delete(int renderRowIndex)
    // {
    //     var row = GetRenderRow(renderRowIndex);
    //     row.Replace(row.CursorIndex, '\0');
    // }
}