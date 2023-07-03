using static System.Console;


Choice();
static string Choice()
{
    Write("Select a task by pressing the corresponding number:\n" +
    "1. Multiplication of a matrix by a number.\n" +
    "2. Matrix addition.\n" +
    "3. Matrices MatricesDivision.\n" +
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
        case "3":
            MatricesDivision();
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
        if (rows < 1 || cols < 1)
        {
            WriteLine("Wrong input! The number of rows and columns in the array" +
            " must be at least one! Try again!");
            return MultiByNum();
        }
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
        WriteLine("Wrong input! Try again!");
        return MultiByNum();
    }
    WriteLine("Press R to repeat. Press M to main menu. Press any to quit.");
    string? answer = ReadLine();
    switch (answer?.ToLower())
    {
        case "r":
            return MultiByNum();
        case "m":
            return Choice();
        default:
            WriteLine("Have a nice day!");
            break;
    }
    return "";
}
static string MatricesAdd()
{
    Write("Enter the numer of rows: ");
    string? row = ReadLine();
    Write("Ener the number of cols: ");
    string? col = ReadLine();
    if (int.TryParse(row, out int rows) &&
        int.TryParse(col, out int cols))
    {
        if (rows < 1 || cols < 1)
        {
            WriteLine("Wrong input! The number of rows and columns in the array" +
            " must be at least one! Try again!");
            return MatricesAdd();
        }
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
    else
    {
        WriteLine("Wrong input! Try again!");
        return MultiByNum();
    }
    WriteLine("Press R to repeat. Press M to main menu. Press any to quit.");
    string? answer = ReadLine();
    switch (answer?.ToLower())
    {
        case "r":
            return MatricesAdd();
        case "m":
            return Choice();
        default:
            WriteLine("Have a nice day!");
            break;
    }
    return "";
}
static string MatricesDivision()
{
    Write("Enter the numer of rows: ");
    string? row = ReadLine();
    Write("Ener the number of cols: ");
    string? col = ReadLine();
    if (int.TryParse(row, out int rows) &&
        int.TryParse(col, out int cols))
    {
        if (rows < 1 || cols < 1)
        {
            WriteLine("Wrong input! The number of rows and columns in the array" +
            " must be at least one! Try again!");
            return MatricesDivision();
        }
        double[,] arr = new double[rows, cols];
        double[,] arr2 = new double[rows, cols];
        double[,] buff = new double[rows, cols];
        Random random = new Random();
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = random.Next(0, 9);
                arr2[i, j] = random.Next(10, 19);
                Write($" {arr[i, j]} / {arr2[i, j]} = ");
                buff[i, j] = arr[i, j] / arr2[i, j];
                Write($" {buff[i, j]} ");
            }
            WriteLine();
        }
    }
    else
    {
        WriteLine("Wrong input! Try again!");
        return MatricesDivision();
    }
    WriteLine("Press R to repeat. Press M to main menu. Press any to quit.");
    string? answer = ReadLine();
    switch (answer?.ToLower())
    {
        case "r":
            return MatricesDivision();
        case "m":
            return Choice();
        default:
            WriteLine("Have a nice day!");
            break;
    }
    return "";
}
