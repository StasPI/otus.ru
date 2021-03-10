using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace TetrisSb
{
   class GuiDrawer : IDrawer
   {
      public const int SIZE = 20;
      public void InitField()
      {
         GraphicsWindow.BackgroundColor = "Dark";
         GraphicsWindow.Height = Field.Height * SIZE;
         GraphicsWindow.Width = Field.Width * SIZE;
      }

      public void DrawPoint(int x, int y)
      {
         GraphicsWindow.PenColor = "White";
         GraphicsWindow.PenWidth = 2;
         GraphicsWindow.DrawRectangle(x * SIZE, y * SIZE, SIZE, SIZE);
      }

      public void HidePoint(int x, int y)
      {
         GraphicsWindow.PenColor = GraphicsWindow.BackgroundColor;
         GraphicsWindow.PenWidth = 2;
         GraphicsWindow.DrawRectangle(x * SIZE, y * SIZE, SIZE, SIZE);
      }

      public void WriteGameOver()
      {
         GraphicsWindow.BrushColor = "Red";
         GraphicsWindow.FontSize = 20;
         GraphicsWindow.DrawText((Field.Width / 2 - 4) * SIZE, (Field.Height / 2) * SIZE, "G A M E   O V E R");
      }
   }
}
