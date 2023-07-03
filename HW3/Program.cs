// See https://aka.ms/new-console-template for more information
using static System.Console;

Choice();

static string Choice()
{
    Write("Select a task by pressing the corresponding number:\n" +
    "1. Multiplication of a matrix by a number.\n" +
    "2. Matrix addition.\n" +
    "3. Product of matrices.\n" +
    "To repeat press Y or Q for exit program!\n");
    string? userChoice = ReadLine();
    switch (userChoice?.ToLower())
    {
        case "y":
            return Choice();
        case "q":
            WriteLine("Have a nice day!");
            return "";
        case "1":
            MultiByNum();
            break;
        case "2":
            MatricesAdd();
            break;
        default:
            WriteLine("Wrong input! Try again!");
            return Choice();
    }
    return "";
}
static string MultiByNum()
{
    Write("Enter the numer of rows: ");
    string? row = ReadLine();
    Write("Ener the number of cols: ");
    string? col = ReadLine();
    Write("Enter the number for multiplication: ");
    string? num = ReadLine();
    if (int.TryParse(num, out int nums) && int.TryParse(row, out int rows) &&
        int.TryParse(col, out int cols))
    {
        int[,] arr = new int[rows, cols];
        int[,] buff = new int[rows, cols];
        Random random = new Random();
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = random.Next(0, 9);
                Write($" {arr[i, j]} * {num} = ");
                buff[i, j] = arr[i, j] * Convert.ToInt32(num);
                Write($" {buff[i, j]} ");
            }
            WriteLine();
        }
    }
    else
    {
        return MultiByNum();
    }
    return "";
}
static void MatricesAdd()
{
    Write("Enter the numer of rows: ");
    int rows = Convert.ToInt32(ReadLine());
    Write("Ener the number of cols: ");
    int cols = Convert.ToInt32(ReadLine());
    Write("Enter the number for multiplication: ");
    int num = Convert.ToInt32(ReadLine());
    int[,] arr = new int[rows, cols];
    int[,] arr2 = new int[rows, cols];
    int[,] buff = new int[rows, cols];
    Random random = new Random();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = random.Next(0, 9);
            arr2[i, j] = random.Next(10, 19);
            Write($" {arr[i, j]} + {arr2[i, j]} = ");
            buff[i, j] = arr[i, j] + arr2[i, j];
            Write($" {buff[i, j]} ");
        }
        WriteLine();
    }
}
