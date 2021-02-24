using System.Linq;

namespace Tetris
{
   abstract class Figure
   {
      const int LENGHT = 4;
      protected Point[] points = new Point[LENGHT];
      private object p;

      public void Draw()
      {
         foreach (Point p in points)
         {
            p.Draw();
         }
      }

      internal void TryMove(Direction dir)
      {
         Hide();
         var clone = Clone();
         Move(clone, dir);
         if (VerifyPosition(clone))
            points = clone;

         Draw();
      }

      internal void TryRotate()
      {
         Hide();
         var clone = Clone();
         Rotate(clone);
         if (VerifyPosition(clone))
            points = clone;

         Draw();
      }

      private bool VerifyPosition(Point[] pList)
      {
         foreach (var p in pList)
         {
            if (p.X < 0 || p.Y < 0 || p.X >= Field.Width || p.Y >= Field.Height)
               return false;
         }

         return true;
      }

      private Point[] Clone()
      {
         var newPoints = new Point[LENGHT];
         foreach (int i in Enumerable.Range(0, LENGHT))
         {
            newPoints[i] = new Point(points[i]);
         }
         return newPoints;
      }

      public void Move(Point[] pList, Direction dir)
      {
         foreach (var p in pList)
         {
            p.Move(dir);
         }
      }

      public void Hide()
      {
         foreach (Point p in points)
         {
            p.Hide();
         }
      }

      public abstract void Rotate(Point[] pList);
   }
}