using System;

namespace CellularAutomata
{
    class Program
    {
        const uint HEIGHT = 10;
        const uint WIDTH = 10;
        static void Main(string[] args)
        {
            byte[,] cells = new byte[WIDTH + 2, HEIGHT + 2];
            for (int i = 0; i < WIDTH + 2; i++)
            {
                cells[i, 0] = 0;
                cells[i, WIDTH + 1] = 0;
            }
            for (int j = 0; j < HEIGHT + 2; j++)
            {
                cells[0, j] = 0;
                cells[HEIGHT+1, j] = 0;
            }

            cells = randomize(cells);



            while (true)
            {
                print(cells);
                //Console.Read();
                iterate(cells);
            }
        }

        static byte[,] randomize(byte[,] cells)
        {
            Random random = new Random();
            for (int i = 1; i < WIDTH; i++)
            {
                for (int j = 1; j < HEIGHT; j++)
                {
                    if (random.Next(3) > 1)
                    {
                        cells[i, j] = 1;
                    }
                    else
                        cells[i, j] = 0;
                }
            }
            return cells;
        }
        static byte[,] iterate(byte[,] cells)
        {
            for (int i = 1; i < WIDTH; i++)
            {
                for (int j = 1; j < HEIGHT; j++)
                {
                    int neibours =  cells[i - 1, j - 1] + cells[i - 1, j] + cells[i - 1, j + 1] +
                                    cells[i, j - 1] + cells[i, j + 1] +
                                    cells[i + 1, j - 1] + cells[i + 1, j] + cells[i + 1, j + 1];

                    if (neibours == 3)
                    {
                        cells[i, j] = 1;
                    }
                    else if (neibours < 2 || neibours > 3)
                    {
                        cells[i, j] = 0;
                    }
                }
            }
            return cells;
        }

        static void print(byte[,] cells)
        {
            for (int i = 1; i < WIDTH; i++)
            {
                for (int j = 1; j < HEIGHT; j++)
                {
                    Console.Write(cells[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
