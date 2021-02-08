using System;

namespace Tetris
{
    internal class FigureGenerator
    {

        private int _x;
        private int _y;
        private char _c;
        private Random _rand = new Random();

        public FigureGenerator(int x, int y, char c)
        {
            _x = x;
            _y = y;
            _c = c;
        }

        public Figure GetNewFigure()
        {
            int num = (int)_rand.Next(0, 2);
            switch (num)
            {
                case (int)TypesOfFigures.Squere:
                    return new Stick(_x, _y, _c);
                case (int)TypesOfFigures.Stick:
                    return new Square(_x, _y, _c);
                default:
                    return new Square(_x, _y, _c);
            }
        }
    }
}