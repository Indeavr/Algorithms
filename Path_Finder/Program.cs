using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static char[,] maze =
    {
        {' ', ' ', ' ', 'x', ' ', ' ', ' '},
        {'x', 'x', ' ', 'x', ' ', 'x', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', 'x', 'x', 'x', 'x', 'x', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'e'}
    };

    static List<char> path = new List<char>();

    public static void Main()
    {
        FindPath(0, 0, ' ');
    }

    private static void FindPath(int row, int col, char direction)
    {
        if (col < 0 || row < 0 || col >= maze.GetLength(1) || row >= maze.GetLength(0))
        {
            return;
        }

        if (direction != ' ' && maze[row, col] == ' ')
        {
            path.Add(direction);
        }

        if (maze[row, col] == 'e')
        {
            Console.WriteLine(string.Join(",", path) + "," + direction);
            Console.WriteLine("GG");
            return;
        }

        if (maze[row, col] != ' ')
        {
            return;
        }

        maze[row, col] = 'v';

        FindPath(row, col - 1, 'L');
        FindPath(row, col + 1, 'R');
        FindPath(row - 1, col, 'U');
        FindPath(row + 1, col, 'D');

        maze[row, col] = ' ';

        if (path.Any())
        {
            path.RemoveAt(path.Count - 1);
        }
    }
}