using System;
using System.Linq;
using System.Threading;

class Player
{
    public string Name { get; set; }
    public ConsoleColor Color { get; set; }
    public char Symb { get; set; }
    public int Score { get; set; } = 0;
}

class Program
{
    static void Main()
    {
        Console.Title = "Tic-Tac-Toe";
        Console.BufferHeight = 100;
        Console.WindowHeight = 16;
        Console.WindowWidth = 80;
        Console.CursorVisible = false;

        Player player1 = new Player();
        Player player2 = new Player();

        player1.Color = ConsoleColor.Blue;
        player2.Color = ConsoleColor.Red;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition((Console.WindowWidth - 19) / 2, 0);
        Console.Write("Set ");
        Console.ForegroundColor = player1.Color;
        Console.Write("Player1's ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Name:");
        CheckPlayerName(ref player1);
        ClearVisibleConsole();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition((Console.WindowWidth - 19) / 2, 0);
        Console.Write("Set ");
        Console.ForegroundColor = player2.Color;
        Console.Write("Player2's ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Name:");
        CheckPlayerName(ref player2);
        ClearVisibleConsole();

        char[][] matrixOfGame = new char[3][]
        {
            new char[] { ' ', ' ', ' ' },
            new char[] { ' ', ' ', ' ' },
            new char[] { ' ', ' ', ' ' }
        };

        int[][] matrixOfSelections = new int[3][]
        {
            new int[] { 0, 0, 0 },
            new int[] { 0, 0, 0 },
            new int[] { 0, 0, 0 }
        };

        int[] selectedField = { 0, 0 };
        matrixOfSelections[0][0] = 1;

        Random rnd = new Random();

        int counter = rnd.Next(0, 2);

        player1.Symb = 'X';
        player2.Symb = 'O';

        PrintUpdate(matrixOfGame, selectedField, counter, player1, player2);

        // Print credits
        string[] credits = new string[]
        {
            "CREDITS:",
            " ",
            "Main Game Developer: Niki Lubomirov",
            "Game Programmer: Niki Lubomirov",
            "Game Designer: Niki Lubomirov",
            "Publisher: Niki Lubomirov",
            " ",
            "Testers:",
            " ",
            "Martin Donevski (Marty Party)"
        };
        PrintCentredText(credits);
        Console.SetCursorPosition(0, 0);

        bool isNewGame = false;
        while (true)
        {
            ConsoleKeyInfo button = Console.ReadKey(true);

            switch (button.Key)
            {
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (selectedField[1] < 2)
                    {
                        MoveRight(ref matrixOfSelections, ref selectedField);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (selectedField[1] > 0)
                    {
                        MoveLeft(ref matrixOfSelections, ref selectedField);
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (selectedField[0] < 2)
                    {
                        MoveDown(ref matrixOfSelections, ref selectedField);
                    }
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (selectedField[0] > 0)
                    {
                        MoveUp(ref matrixOfSelections, ref selectedField);
                    }
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (!isNewGame)
                    {
                        int selectedRow = selectedField[0];
                        int selectedCol = selectedField[1];

                        if (matrixOfGame[selectedRow][selectedCol] == ' ')
                        {
                            if (counter % 2 == 0)
                            {
                                matrixOfGame[selectedRow][selectedCol] = player1.Symb;
                                Console.Beep(400, 200);
                            }
                            else
                            {
                                matrixOfGame[selectedRow][selectedCol] = player2.Symb;
                                Console.Beep(600, 200);
                            }

                            counter++;
                        }
                    }
                    break;
            }

            ClearVisibleConsole();

            PrintUpdate(matrixOfGame, selectedField, counter, player1, player2);

            isNewGame = false;
            if (HasMatch(matrixOfGame, player1))
            {
                PlayerWins(ref matrixOfGame, ref player1);

                // Updating the player's visual score
                Console.ForegroundColor = player1.Color;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 2, 0);
                Console.Write(player1.Score);
                Console.ForegroundColor = ConsoleColor.Green;

                isNewGame = true;
            }
            else if (HasMatch(matrixOfGame, player2))
            {
                PlayerWins(ref matrixOfGame, ref player2);

                // Updating the player's visual score
                Console.ForegroundColor = player2.Color;
                Console.SetCursorPosition(Console.WindowWidth / 2, 0);
                Console.Write(player2.Score);
                Console.ForegroundColor = ConsoleColor.Green;

                isNewGame = true;
            }

            if (IsFull(matrixOfGame))
            {
                Draw(ref matrixOfGame);

                isNewGame = true;
            }

            if (player1.Score == 3)
            {
                End(player1, player2);
                return;
            }
            else if (player2.Score == 3)
            {
                End(player2, player1);
                return;
            }
        }
    }

    private static void ClearVisibleConsole()
    {
        Console.SetCursorPosition(0, 0);
        string manyTabs = new string('\t', 160);
        Console.Write(manyTabs);
    }

    private static void CheckPlayerName(ref Player player)
    {
        Console.SetCursorPosition((Console.WindowWidth - 10) / 2, 4);
        Console.WriteLine(new string('-', 10));
        Console.ForegroundColor = player.Color;
        Console.SetCursorPosition((Console.WindowWidth - 10) / 2, 3);
        string name = ReadLimited(10);
        Console.ForegroundColor = ConsoleColor.Green;

        while (true)
        {
            if (name == string.Empty)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(new string(' ', 80));
                Console.SetCursorPosition((Console.WindowWidth - 35) / 2, 0);
                Console.Write("The ");
                Console.ForegroundColor = player.Color;
                Console.Write("name ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("can't be empty, try again:");
                Console.SetCursorPosition((Console.WindowWidth - 10) / 2, 4);
                Console.WriteLine(new string('-', 10));
                Console.ForegroundColor = player.Color;
                Console.SetCursorPosition(0, 3);
                Console.WriteLine(new string(' ', 80));
                Console.SetCursorPosition((Console.WindowWidth - 10) / 2, 3);
                name = ReadLimited(10);
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                player.Name = name;
                break;
            }
        }
    }

    private static string ReadLimited(int limit)
    {
        string str = string.Empty;
        while (true)
        {
            char c = Console.ReadKey(true).KeyChar;

            if (c == '\r')
            {
                break;
            }

            if (c == '\b')
            {
                if (str != "")
                {
                    str = str.Substring(0, str.Length - 1);
                    Console.Write("\b \b");
                }
            }
            else if (str.Length < limit)
            {
                Console.Write(c);
                str += c;
            }
        }
        return str;
    }

    private static void MoveRight(ref int[][] matrix, ref int[] selectedField)
    {
        selectedField[1]++;
        int selectedRow = selectedField[0];
        int selectedCol = selectedField[1];

        matrix[selectedRow][selectedCol - 1] = 0;
        matrix[selectedRow][selectedCol] = 1;
    }

    private static void MoveLeft(ref int[][] matrix, ref int[] selectedField)
    {
        selectedField[1]--;
        int selectedRow = selectedField[0];
        int selectedCol = selectedField[1];

        matrix[selectedRow][selectedCol + 1] = 0;
        matrix[selectedRow][selectedCol] = 1;
    }

    private static void MoveDown(ref int[][] matrix, ref int[] selectedField)
    {
        selectedField[0]++;
        int selectedRow = selectedField[0];
        int selectedCol = selectedField[1];

        matrix[selectedRow - 1][selectedCol] = 0;
        matrix[selectedRow][selectedCol] = 1;
    }

    private static void MoveUp(ref int[][] matrix, ref int[] selectedField)
    {
        selectedField[0]--;
        int selectedRow = selectedField[0];
        int selectedCol = selectedField[1];

        matrix[selectedRow + 1][selectedCol] = 0;
        matrix[selectedRow][selectedCol] = 1;
    }

    private static void PrintUpdate(char[][] matrixOfGame, int[] selectedField, int counter, Player player1, Player player2)
    {
        // Printing player's wins
        Console.ForegroundColor = player1.Color;
        Console.SetCursorPosition(Console.WindowWidth / 2 - 2, 0);
        Console.Write(player1.Score);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
        Console.Write(":");
        Console.ForegroundColor = player2.Color;
        Console.SetCursorPosition(Console.WindowWidth / 2, 0);
        Console.WriteLine(player2.Score);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;

        // Printing game's chart
        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 2);
        Console.WriteLine("     ║     ║     ");
        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 3);
        Console.Write("  ");
        Console.ForegroundColor = matrixOfGame[0][0] == player1.Symb ? player1.Color : player2.Color;
        Console.Write(matrixOfGame[0][0]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("  ║  ");
        Console.ForegroundColor = matrixOfGame[0][1] == player1.Symb ? player1.Color : player2.Color;
        Console.Write(matrixOfGame[0][1]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("  ║  ");
        Console.ForegroundColor = matrixOfGame[0][2] == player1.Symb ? player1.Color : player2.Color;
        Console.Write(matrixOfGame[0][2]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ");
        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 4);
        Console.WriteLine("     ║     ║     ");
        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 5);
        Console.WriteLine("═════╬═════╬═════");
        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 6);
        Console.WriteLine("     ║     ║     ");
        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 7);
        Console.Write("  ");
        Console.ForegroundColor = matrixOfGame[1][0] == player1.Symb ? player1.Color : player2.Color;
        Console.Write(matrixOfGame[1][0]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("  ║  ");
        Console.ForegroundColor = matrixOfGame[1][1] == player1.Symb ? player1.Color : player2.Color;
        Console.Write(matrixOfGame[1][1]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("  ║  ");
        Console.ForegroundColor = matrixOfGame[1][2] == player1.Symb ? player1.Color : player2.Color;
        Console.Write(matrixOfGame[1][2]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ");
        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 8);
        Console.WriteLine("     ║     ║     ");
        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 9);
        Console.WriteLine("═════╬═════╬═════");
        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 10);
        Console.WriteLine("     ║     ║     ");
        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 11);
        Console.Write("  ");
        Console.ForegroundColor = matrixOfGame[2][0] == player1.Symb ? player1.Color : player2.Color;
        Console.Write(matrixOfGame[2][0]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("  ║  ");
        Console.ForegroundColor = matrixOfGame[2][1] == player1.Symb ? player1.Color : player2.Color;
        Console.Write(matrixOfGame[2][1]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("  ║  ");
        Console.ForegroundColor = matrixOfGame[2][2] == player1.Symb ? player1.Color : player2.Color;
        Console.Write(matrixOfGame[2][2]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ");
        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 12);
        Console.WriteLine("     ║     ║     ");

        int selectedRow = selectedField[0];
        int selectedCol = selectedField[1];

        // Printing the selection
        Console.ForegroundColor = counter % 2 == 0 ? player1.Color : player2.Color;
        Console.SetCursorPosition(selectedCol * 6 + 31, selectedRow * 4 + 2);

        Console.WriteLine("┌───┐");
        Console.SetCursorPosition(selectedCol * 6 + 31, selectedRow * 4 + 3);
        Console.WriteLine("│");
        Console.SetCursorPosition(selectedCol * 6 + 35, selectedRow * 4 + 3);
        Console.WriteLine("│");
        Console.SetCursorPosition(selectedCol * 6 + 31, selectedRow * 4 + 4);
        Console.WriteLine("└───┘");

        Console.ForegroundColor = ConsoleColor.Green;

        // Printing current turn
        if (counter % 2 == 0)
        {
            Console.ForegroundColor = player1.Color;
            string turnInfo = $"{player1.Name}'s turn";
            Console.SetCursorPosition((Console.WindowWidth - turnInfo.Length) / 2, 14);
            Console.WriteLine(turnInfo);
        }
        else
        {
            Console.ForegroundColor = player2.Color;
            string turnInfo = $"{player2.Name}'s turn";
            Console.SetCursorPosition((Console.WindowWidth - turnInfo.Length) / 2, 14);
            Console.WriteLine(turnInfo);
        }
        Console.ForegroundColor = ConsoleColor.Green;
    }

    private static void PrintCentredText(string[] texts)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            string str = texts[i];
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, i + 18);
            Console.WriteLine(str);
        }
    }

    private static bool HasMatch(char[][] matrix, Player p)
    {
        return ((matrix[0][0] == p.Symb && matrix[0][1] == p.Symb && matrix[0][2] == p.Symb) ||
                (matrix[1][0] == p.Symb && matrix[1][1] == p.Symb && matrix[1][2] == p.Symb) ||
                (matrix[2][0] == p.Symb && matrix[2][1] == p.Symb && matrix[2][2] == p.Symb) ||

                (matrix[0][0] == p.Symb && matrix[1][0] == p.Symb && matrix[2][0] == p.Symb) ||
                (matrix[0][1] == p.Symb && matrix[1][1] == p.Symb && matrix[2][1] == p.Symb) ||
                (matrix[0][2] == p.Symb && matrix[1][2] == p.Symb && matrix[2][2] == p.Symb) ||

                (matrix[0][0] == p.Symb && matrix[1][1] == p.Symb && matrix[2][2] == p.Symb) ||
                (matrix[0][2] == p.Symb && matrix[1][1] == p.Symb && matrix[2][0] == p.Symb));
    }

    private static void PlayerWins(ref char[][] matrix, ref Player player)
    {
        player.Score++;

        matrix = new char[3][]
        {
            new char[] { ' ', ' ', ' ' },
            new char[] { ' ', ' ', ' ' },
            new char[] { ' ', ' ', ' ' }
        };

        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 14);
        Console.WriteLine(new string(' ', 17));
        Console.ForegroundColor = player.Color;
        string turnInfo = $"{player.Name} WON !!!";
        Console.SetCursorPosition((Console.WindowWidth - turnInfo.Length) / 2, 14);
        Console.WriteLine(turnInfo);
    }

    private static bool IsFull(char[][] matrix)
    {
        return !matrix[0].Contains(' ') && !matrix[1].Contains(' ') && !matrix[2].Contains(' ');
    }

    private static void Draw(ref char[][] matrix)
    {
        matrix = new char[3][]
        {
            new char[] { ' ', ' ', ' ' },
            new char[] { ' ', ' ', ' ' },
            new char[] { ' ', ' ', ' ' }
        };

        Console.SetCursorPosition((Console.WindowWidth - 17) / 2, 14);
        Console.WriteLine(new string(' ', 17));
        string drawMessage = "DRAW !!!";
        Console.SetCursorPosition((Console.WindowWidth - drawMessage.Length) / 2, 14);
        Console.WriteLine(drawMessage);
    }

    private static void End(Player winner, Player loser)
    {
        Console.ReadKey();

        Console.Clear();

        // Playing mission impossible
        Console.Beep(784, 150);
        Thread.Sleep(300);
        Console.Beep(784, 150);
        Thread.Sleep(300);
        Console.Beep(932, 150);
        Thread.Sleep(150);
        Console.Beep(1047, 150);
        Thread.Sleep(150);
        Console.Beep(784, 150);
        Thread.Sleep(300);

        Console.ForegroundColor = ConsoleColor.Green;
        string endText1 = "Thank U for playing, you are AWESOME !!!";
        Console.SetCursorPosition((Console.WindowWidth - endText1.Length) / 2, 5);
        Console.WriteLine(endText1);

        Console.Beep(784, 150);
        Thread.Sleep(300);
        Console.Beep(699, 150);
        Thread.Sleep(150);
        Console.Beep(740, 150);
        Thread.Sleep(150);
        Console.Beep(784, 150);
        Thread.Sleep(300);
        Console.Beep(784, 150);
        Thread.Sleep(300);
        Console.Beep(932, 150);
        Thread.Sleep(150);

        ConsoleColor winnerDarkerColor = ConsoleColor.DarkGreen;
        ConsoleColor loserDarkerColor = ConsoleColor.DarkGreen;
        if (winner.Color == ConsoleColor.Blue)
        {
            winnerDarkerColor = ConsoleColor.DarkBlue;
            loserDarkerColor = ConsoleColor.DarkRed;
        }
        else
        {
            winnerDarkerColor = ConsoleColor.DarkRed;
            loserDarkerColor = ConsoleColor.DarkBlue;
        }
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        int darkerMessageLenght = $"(I mean you - {winner.Name}, not {loser.Name})".Length;
        Console.SetCursorPosition((Console.WindowWidth - darkerMessageLenght) / 2, 6);
        Console.Write("(I mean you - ");
        Console.ForegroundColor = winnerDarkerColor;
        Console.Write(winner.Name);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(", not ");
        Console.ForegroundColor = loserDarkerColor;
        Console.Write(loser.Name);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(")");

        Console.Beep(1047, 150);
        Thread.Sleep(150);
        Console.Beep(784, 150);
        Thread.Sleep(300);
        Console.Beep(784, 150);
        Thread.Sleep(300);
        Console.Beep(699, 150);
        Thread.Sleep(150);
        Console.Beep(740, 150);
        Thread.Sleep(150);
        Console.Beep(932, 150);
        Console.Beep(784, 150);
        Console.Beep(587, 1200);
        Thread.Sleep(75);

        Console.ForegroundColor = ConsoleColor.Green;
        string pressKey = "Press any key to exit...";
        Console.SetCursorPosition((Console.WindowWidth - pressKey.Length) / 2, 9);
        Console.WriteLine(pressKey);

        Console.Beep(932, 150);
        Console.Beep(784, 150);
        Console.Beep(554, 1200);
        Thread.Sleep(75);
        Console.Beep(932, 150);
        Console.Beep(784, 150);
        Console.Beep(523, 1200);
        Thread.Sleep(150);
        Console.Beep(466, 150);
        Console.Beep(523, 150);

        Console.ReadKey();
    }
}