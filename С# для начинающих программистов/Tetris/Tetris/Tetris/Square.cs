namespace Tetris
{
   class Square : Figure
   {
      public Square(int x, int y, char sym)
      {
         points[0] = new Point(x, y, sym);
         points[1] = new Point(x + 1, y, sym);
         points[2] = new Point(x, y + 1, sym);
         points[3] = new Point(x + 1, y + 1, sym);
         Draw();
      }

      public override void Rotate(Point[] pList)
      {
         if (points[0].X == points[1].X)
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
         for (int i = 0; i < points.Length; i++)
         {
            points[i].X = points[0].X;
            points[i].Y = points[0].Y + i;
         }
      }

      private void RotateHorisontal()
      {
         for (int i = 0; i < points.Length; i++)
         {
            points[i].Y = points[0].Y;
            points[i].X = points[0].X + i;
         }
      }
   }
}