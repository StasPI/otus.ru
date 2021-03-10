namespace TetrisSb
{
   interface IDrawer
   {
      void DrawPoint(int x, int y);
      void HidePoint(int x, int y);
      void InitField();
      void WriteGameOver();
   }
}