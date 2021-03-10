using System;

namespace TetrisGUI
{
   class ConsoleDrawer : IDrawer
   {
      public void DrawPoint(int x, int y)
      {
         Console.SetCursorPosition(x, y);
         Console.Write('*');
         Console.SetCursorPosition(0, 0);
      }

      public void HidePoint(int x, int y)
      {
         Console.SetCursorPosition(x, y);
         Console.Write(' ');
         Console.SetCursorPosition(0, 0);
      }
   }
}
