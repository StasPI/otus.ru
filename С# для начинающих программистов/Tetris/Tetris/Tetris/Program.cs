using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            char z = '*';

            Figure s = new Stick(20, 5, z);
            s.Draw();

            Thread.Sleep(500);
            s.Hide();
            s.Rotate();
            s.Draw();

            Thread.Sleep(500);
            s.Hide();
            s.Rotate();
            s.Draw();

            Thread.Sleep(500);
            s.Hide();
            s.Rotate();
            s.Draw();

            Thread.Sleep(500);
            s.Hide();
            s.Rotate();
            s.Draw();


            //s.Move(Direction.LEFT);


            //Figure[] f = new Figure[2];
            //f[0] = new Square(2, 5, z);
            //f[1] = new Stick(6, 6, z);

            //foreach (Figure fig in f)
            //{
            //    fig.Draw();
            //}

            Console.ReadLine();
        }

    }
}
