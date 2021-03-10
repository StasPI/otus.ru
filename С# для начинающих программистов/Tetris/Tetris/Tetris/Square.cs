namespace Tetris
{
   class Square : Figure
   {
      public Square(int x, int y, char sym)
      {
         Points[0] = new Point(x, y, sym);
         Points[1] = new Point(x + 1, y, sym);
         Points[2] = new Point(x, y + 1, sym);
         Points[3] = new Point(x + 1, y + 1, sym);
         Draw();
      }

      public override void Rotate()
      {
         if (Points[0].X == Points[1].X)
         {
            RotateHorisontal();
         }
         else
         {
            RotateVertical();
         }
      }

      private void RotateVertical()
      {
         for (int i = 0; i < Points.Length; i++)
         {
            Points[i].X = Points[0].X;
            Points[i].Y = Points[0].Y + i;
         }
      }

      private void RotateHorisontal()
      {
         for (int i = 0; i < Points.Length; i++)
         {
            Points[i].Y = Points[0].Y;
            Points[i].X = Points[0].X + i;
         }
      }
   }
}