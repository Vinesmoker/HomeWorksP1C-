class Program 
{
    delegate string GetDayOfWeek();
    static void Main() 
    {
        string[] days = { "Sanday", "Monday", "Tuesday", "Wednesday", "Thursday", "Ftiday", "Saturday" };
        int id = 0;
        GetDayOfWeek getNextDay = delegate
        {
            string nextDay = days[id];
            id = (id + 1) % days.Length;
            return nextDay;
        };
        for (int i = 0; i < 25; i++) 
        {
            string nextDay = getNextDay();
            Console.WriteLine(nextDay);
        }
    }
}
