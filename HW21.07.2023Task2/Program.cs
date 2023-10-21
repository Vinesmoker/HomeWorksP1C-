class Program 
{
    delegate double Function(double x);
    static void Main() 
    {
        double a = 3.0; double b = 4.0; double c = 5.0;
        Function qDelegate = MakeFunction(a, b, c);
        double x1 = 2.0;
        double result1 = qDelegate(x1);
        Console.WriteLine($"Result if x = {x1}: {result1}");
        double x2 = 3.0;
        double result2 = qDelegate(x2);
        Console.WriteLine($"Result if x = {x2}: {result2}");
    }
    static Function MakeFunction(double a, double b, double c) 
    {
        Function func = (x) => a * x * x + b * x + c;
        return func;
    }
}