using System;
using System.Linq;

namespace TetrisGUI
{
   abstract class Figure
   {
      const int LENGHT = 4;
      public Point[] Points = new Point[LENGHT];
      private object p;

      public void Draw()
      {
         foreach (Point p in Points)
         {
            p.Draw();
         }
      }

      internal Result TryMove(Direction dir)
      {
         Hide();
         Move(dir);

         var result = VerifyPosition();
         if (result != Result.SUCCESS)
            Move(Reversed(dir));

         Draw();
         return result;
      }

      private Direction Reversed(Direction dir)
      {
         switch(dir)
         {
            case Direction.LEFT:
               return Direction.RIGHT;
            case Direction.RIGHT:
               return Direction.LEFT;
            case Direction.DOWN:
               return Direction.UP;
            case Direction.UP:
               return Direction.DOWN;
         }
         return dir;
      }

      internal Result TryRotate()
      {
         Hide();
         Rotate();

         var result = VerifyPosition();
         if (result != Result.SUCCESS)
            Rotate();

         Draw();
         return result;
      }

      private Result VerifyPosition()
      {
         foreach (var p in Points)
         {
            if (p.Y >= Field.Height)
               return Result.DOWN_BORDER_STRIKE;
            if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
               return Result.BORDER_STRIKE;
            if (Field.CheckStrike(p))
               return Result.HEAP_STRIKE;
         }
         return Result.SUCCESS;
      }

      internal bool IsOnTop()
      {
         return Points[0].Y == 0;
      }

      public void Move(Direction dir)
      {
         foreach (var p in Points)
         {
            p.Move(dir);
         }
      }

      public void Hide()
      {
         foreach (Point p in Points)
         {
            p.Hide();
         }
      }

      public abstract void Rotate();
   }
}