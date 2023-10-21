class Fraction
{
    private int integer;
    private int numerator;
    private int denominator;
    public delegate Fraction FractOper(Fraction a, Fraction b);
    public Fraction(int integer, int numerator, int denominator)
    {
        this.integer = integer;
        this.numerator = numerator;
        this.denominator = denominator;
    }
    public void RegisterAdditionOperation(FractOper operation)
    {
        AddOperation = operation;
    }
    public void RegisterSubtractionOperation(FractOper operation)
    {
        SubtractOperation = operation;
    }
    public void RegisterMultiplicationOperation(FractOper operation)
    {
        MultiplicatOperation = operation;
    }
    public void RegisterDivisionOperation(FractOper operation)
    {
        DivisionOperation = operation;
    }
    public void ToImproper()
    {
        numerator += integer * denominator;
        integer = 0;
    }
    public void ToProper()
    {
        integer = numerator / denominator;
        numerator %= denominator;
    }
    public void FractionInput()
    {
        Console.Write("Enter an integer: ");
        if (int.TryParse(Console.ReadLine(), out integer)) { }
        else
        {
            Console.WriteLine("Wrong integer!");
            return;
        }
        Console.Write("Enter numerator: ");
        if (int.TryParse(Console.ReadLine(), out numerator)) { }
        else
        {
            Console.WriteLine("Wrong numerator!");
            return;
        }
        do
        {
            Console.Write("Enter denominator: ");
            if (int.TryParse(Console.ReadLine(), out denominator))
            {
                if (denominator == 0)
                {
                    Console.WriteLine("Denominator has to be more than 0!");
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Wrong denominator!");
            }
        } while (true);
        ToImproper();
    }
    public void FractionOutput()
    {
        ToProper();
        int gcd = FindGCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
        Console.WriteLine($"{integer} {numerator}/{denominator}");
    }
    private static int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    public Fraction Add(Fraction other)
    {
        if (AddOperation != null)
        {
            return AddOperation(this, other);
        }
        else
        {
            ToImproper();
            other.ToImproper();
            int num = numerator * other.denominator + other.numerator * denominator;
            int denom = denominator * other.denominator;
            return new Fraction(0, num, denom);
        }
    }
    public Fraction Subtract(Fraction other)
    {
        if (SubtractOperation != null)
        {
            return SubtractOperation(this, other);
        }
        else
        {
            ToImproper();
            other.ToImproper();
            int num = numerator * other.denominator - other.numerator * denominator;
            int denom = denominator * other.denominator;
            return new Fraction(0, num, denom);
        }
    }
    public Fraction Multiplicat(Fraction other)
    {
        if (MultiplicatOperation != null)
        {
            return MultiplicatOperation(this, other);
        }
        else
        {
            ToImproper();
            other.ToImproper();
            int num = numerator * other.numerator;
            int denom = denominator * other.denominator;
            return new Fraction(0, num, denom);
        }
    }
    public Fraction Division(Fraction other)
    {
        if (DivisionOperation != null)
        {
            return DivisionOperation(this, other);
        }
        else
        {
            ToImproper();
            other.ToImproper();
            if (other.numerator == 0)
            {
                Console.WriteLine("Division by 0 is not allowed!");
                return new Fraction(0, 0, 1);
            }
            int num = numerator * other.denominator;
            int denom = denominator * other.numerator;
            return new Fraction(0, num, denom);
        }
    }
    private FractOper? AddOperation { get; set; }
    private FractOper? SubtractOperation { get; set; }
    private FractOper? MultiplicatOperation { get; set; }
    private FractOper? DivisionOperation { get; set; }
}

class Program
{
    static void Main()
    {
        do
        {
            Fraction fract1 = new (0, 0, 1);
            Fraction fract2 = new (0, 0, 1);
            Console.WriteLine("Enter the first fraction:");
            fract1.FractionInput();
            Console.Write("Enter an operation (+, -, *, /): ");
            if (char.TryParse(Console.ReadLine(), out char operation)) { }
            else
            {
                Console.WriteLine("Wrong integer.");
            }
            Console.WriteLine("Enter the second fraction:");
            fract2.FractionInput();
            Fraction? result = null;
            switch (operation)
            {
                case '+':
                    result = fract1.Add(fract2);
                    break;
                case '-':
                    result = fract1.Subtract(fract2);
                    break;
                case '*':
                    result = fract1.Multiplicat(fract2);
                    break;
                case '/':
                    result = fract1.Division(fract2);
                    break;
                default:
                    Console.WriteLine("Wrong operation");
                    break;
            }
            if (result != null)
            {
                Console.Write("Result: ");
                result.FractionOutput();
            }
            Console.Write("Repeat (Y/N)? ");
        } while (Console.ReadLine()?.ToLower() == "y");
    }
}
