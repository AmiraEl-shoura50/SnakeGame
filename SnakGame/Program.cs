using System;
using System.Threading;

namespace SnakeGame
{
    internal class Snake
    {
        int width = 30;
        int heihgt = 20;
        int[] X = new int[50];
        int[] Y = new int[50];
        int fruitX;
        int fruitY;
        int parts = 3;
        ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
        char key = 'w';
        Random rnd = new Random();

        Snake()
        {
            X[0] = 5;
            Y[0] = 5;
            Console.CursorVisible = false;
            fruitX = rnd.Next(2, (width - 2));
            fruitY = rnd.Next(2, (heihgt - 2));
        }

        public void WriteBoard()
        {
            Console.Clear();
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("_");
            }
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, (heihgt + 2));
                Console.Write("_");
            }
            for (int i = 2; i <= (heihgt + 2); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 2; i <= (heihgt + 2); i++)
            {
                Console.SetCursorPosition((width + 2), i);
                Console.Write("|");
            }
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyinfo = Console.ReadKey(true);
                key = keyinfo.KeyChar;
            }
        }

        public void WritePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }

        public void logic()
        {
            if (X[0] == fruitX && Y[0] == fruitY)
            {
                parts++;
                fruitX = rnd.Next(2, (width - 2));
                fruitY = rnd.Next(2, (heihgt - 2));
            }

            for (int i = parts; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }

            switch (key)
            {
                case '4':
                    Y[0]--;
                    break;
                case '6':
                    Y[0]++;
                    break;
                case '2':
                    X[0]++;
                    break;
                case '8':
                    X[0]--;
                    break;
            }

            for (int i = 0; i < parts; i++)
            {
                WritePoint(Y[i], X[i]);
            }

            // Write the fruit after the snake to ensure it's visible
            WritePoint(fruitX, fruitY);

            Thread.Sleep(100);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Snake s = new Snake();
            while (true)
            {
                s.WriteBoard();
                s.Input();
                s.logic();
            }
            // Console.ReadKey();  // Note: Uncomment this line if you want to wait for a key press before exiting
        }
    }
}
