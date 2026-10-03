namespace MeowPaw.Terminal.Core;

public class RenderRow(int rowLength)
{
    // public bool IsWrap { get; set; } = false;
    //
    // public char[] Text = new char[rowLength];
    //
    // public int CursorIndex { get; set; } = -1; //-1代表鼠标指针在当前行不存在
    //
    // public void Write(char c)
    // {
    //     if (CursorIndex == rowLength)
    //     {
    //         throw new InvalidOperationException("Row full.");
    //     }
    //     
    //     if (CursorIndex is -1)
    //     {
    //         CursorIndex = 0;
    //     }
    //
    //     Text[CursorIndex] = c;
    //     CursorIndex++;
    // }
    //
    // //替换掉行中某个位置的字符
    // public void Replace(int index, char c)
    // {
    //     Text[index] = c;
    // }
    //
    // public void ClearCursor()
    // {
    //     CursorIndex = -1;
    // }
    //
    // public int GetRemainCount()
    // {
    //     return rowLength - CursorIndex;
    // }
}