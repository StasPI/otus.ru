using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGUI
{
   static class DrawerProvier
   {
      private static IDrawer _drawer = new ConsoleDrawer();
      public static IDrawer Drawer
      {
         get
         {
            return _drawer;
         }
      }
   }
}
