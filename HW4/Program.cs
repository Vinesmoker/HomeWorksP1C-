// See https://aka.ms/new-console-template for more information
using static System.Console;
internal class Program
{
    static int arrBoard = 8;
    static char[,] board = new char[arrBoard, arrBoard];
    static int startPosRow = 0;
    static int startPosCol = 2;
    static bool CorrectMove(int endPosRow, int endPosCol)  // Checking the correctness of the move.
    {
        int row = Math.Abs(endPosRow - startPosRow);
        int col = Math.Abs(endPosCol - startPosCol);
        return (row == 2 && col == 1) || (row == 1 && col == 2);
    }
    static void BoardPrint()  // Board output to console.
    {
        int buff = 1;
        WriteLine("  A B C D E F G H");
        for (int i = arrBoard; i > 0; i--)
        {
            Write($"{buff++} ");
            for (int col = 0; col < arrBoard; col++) Write($"{board[i - 1, col]}" +
                $"{board[i - 1, col]}");
            WriteLine();
        }
    }
    static void Main(string[] args)
    {
        WriteLine("Make a horse move:");
        WriteLine();
        for (int rows = 0; rows < arrBoard; rows++)
        {
            for (int cols = 0; cols < arrBoard; cols++)
            {
                if ((rows + cols) % 2 == 0) board[rows, cols] = ' ';
                else board[rows, cols] = '\u2588';
            }
        }
        board[startPosRow, startPosCol] = 'H'; // Put the horse on the board.
        BoardPrint();
        while (true)
        {
            WriteLine("Enter the destination cage of the horse by " +
                "entering a letter and a number without a space:");
            string? move = ReadLine().ToUpper();
            if (move.Length != 2 || !char.IsLetter(move[0]) || !char.IsDigit(move[1]))
            {
                WriteLine("Wrong input! Try again!");
                continue;
            }
            int endPosCol = move[0] - 'A';
            int endPosRow = arrBoard - int.Parse(move[1].ToString());
            if (CorrectMove(endPosRow, endPosCol))
            {
                if (startPosRow % 2 == 0 && startPosCol % 2 == 0)
                {
                    board[startPosRow, startPosCol] = ' ';
                }
                else board[startPosRow, startPosCol] = '\u2588';
                board[endPosRow, endPosCol] = 'H';
                startPosRow = endPosRow;
                startPosCol = endPosCol;
                BoardPrint();
            }
            else WriteLine("Wrong move! Try again!");
        }
    }
}
