// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;
using static System.Console;
namespace HW1 
{
    internal class Program 
    {
        static string Choice()          // The method for selecting tasks.
        {
            WriteLine($"Select a task to chek by pressing corresponding number:\n" +
                    $"1. Value range.\n" +
                    $"2. Interest calculation.\n" +
                    $"3. A String of digits.\n" +
                    $"4. Shifting.\n" +
                    $"If You want to quit the program press Q!");
            string answer = ReadLine();  
            switch (answer.ToLower()) 
            {
                case "q":
                    break;
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                default:
                    WriteLine("Wrong input or there no such task! Try again!"); 
                    return Choice();
            }
            if (answer == "Q" || answer == "q")
            {
                return "";
            }
        return "";
        }
        static string Task1() 
        {
            WriteLine("Enter any integer digit between 1 and 100 inclusive: ");
            string number = ReadLine();
            if (int.TryParse(number, out int digit)) // Check digit.
            {
                if ((digit % 3) == 0 && (digit % 5 == 0)) // Solution
                {
                    WriteLine("Fizz Buzz");
                }
                else if ((digit % 5 == 0))
                {
                    WriteLine("Buzz");
                }
                else if ((digit % 3) == 0)
                {
                    WriteLine("Fizz");
                }
                else if (digit < 1 || digit > 100)
                {
                    WriteLine("Wrong input! The number must be between 1 and 100 inclusive! Try again!");
                    return Task1();
                }
                else 
                {
                    WriteLine(digit);
                }
            }
            else 
            {
                WriteLine("Error! You need to enter a integer digit, not a symbol or a letter! Try again!");
                return Task1();
            }
            WriteLine("If You want to repeat press Y, to quit the task press any key!");
            string answer = ReadLine();
            if (answer.ToLower() == "y")   // Condition for selection
            {
                return Task1();
            }
            else
            {
                return Choice();
            }
        }
        static string Task2()
        {
            Write("Enter two numbers. The first number is the value, the second is the percentage.\n" +
                "Enter the first number: ");
            string number = ReadLine();
            Write("Enter the percentage: ");
            string percentage = ReadLine();
            if (double.TryParse(number, out double num) &&
                double.TryParse(percentage, out double perc)) // Check digit.
            {
                if (perc < 1 || perc > 100) // Examination. Percentage must be >= 1 and <= 100.
                {
                    WriteLine("Wrong input! Percentage must be >= 1 and <= 100! Try again!");
                    return Task2();
                }
                double result = (num * (perc / 100)); // Solution.
                WriteLine($"Calculation result: {perc}% of {num} = {result}");
            }
            else 
            {
                WriteLine("Error! You need to enter a digit, not a symbol or a letter! Try again!");
                return Task2();
            }

            WriteLine("If You want to repeat press Y, to quit the task press any key!");
            string answer = ReadLine();
            if (answer.ToLower() == "y")   // Condition for selection.
            {
                return Task2();
            }
            else
            {
                return Choice();
            }
        }
        static string Task3() 
        {
            WriteLine("Enter four positive integers, separated by space.");
            string digits = ReadLine().Replace(" ", "");
            int buffer = 0;
            for (int i = 0; i < digits.Length; i++) // Solution
            {
                if (char.IsDigit(digits[i]))
                {
                    int digit = Convert.ToInt32(digits[i].ToString()); // Symbol to digit
                    buffer += digit * (int)Math.Pow(10, digits.Length - i - 1);
                }
                else 
                {
                    WriteLine("Wrong input! Enter only positive integers! Try again!");
                    return Task3();
                }
            }
            WriteLine($"The result is: {buffer}");

            WriteLine("If You want to repeat press Y, to quit the task press any key!");
            string answer = ReadLine();
            if (answer.ToLower() == "y")   // Condition for selection.
            {
                return Task3();
            }
            else
            {
                return Choice();
            }
        }
        static string Task4() 
        {
            WriteLine("Enter six integers, separated by space:");
            string num = ReadLine();
            string[] numbers = num.Split(' '); // Separation by space.
            if (numbers.Length == 6 && int.TryParse(numbers[0], out int num1) &&
                int.TryParse(numbers[1], out int num2) && int.TryParse(numbers[2], out int num3) &&
                int.TryParse(numbers[3], out int num4) && int.TryParse(numbers[4], out int num5) &&
                int.TryParse(numbers[5], out int num6)) // Test for six integers.
            {
                WriteLine("Enter positions of digits to swap, separated be space: ");
                string posIn = ReadLine();
                string[] positions = posIn.Split(' '); // Separation by space.
                if (positions.Length == 2 && int.TryParse(positions[0], out int pos1) &&
                    int.TryParse(positions[1], out int pos2)) // Test for 2 integer positions.
                {
                    if (pos1 >= 1 && pos1 <= numbers.Length && pos2 >= 1 && pos2 <= numbers.Length) // Test for scopes of entered positions
                    {
                        // Replacing numbers
                        int[] digits = { num1, num2, num3, num4, num5, num6 };  
                        int buff = digits[pos1 - 1];
                        digits[pos1 - 1] = digits[pos2 - 1];
                        digits[pos2 - 1] = buff;
                        WriteLine($"The result is: {string.Join(" ", digits)}");
                    }
                    else
                    {
                        WriteLine("Error! Incorrect entry of digits! Try again!");
                        return Task4();
                    }
                }
                else
                {
                    WriteLine("Error! Incorrect entry of digits! Try again!");
                    return Task4();
                }
            }
            else 
            {
                WriteLine("Error! Incorrect entry of numbers! Try again!");
                return Task4();
            }

            WriteLine("If You want to repeat press Y, to quit the task press any key!");
            string answer = ReadLine();
            if (answer.ToLower() == "y")   // Condition for selection.
            {
                return Task4();
            }
            else
            {
                return Choice();
            }
        }
        static void Main(string[] args) 
        {
            Choice();
        }
    }
}
