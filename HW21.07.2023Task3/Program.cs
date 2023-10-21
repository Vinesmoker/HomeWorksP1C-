class AutoService
{
    public event Action<string> ServiceEvent = delegate { };
    private readonly string serviceName;
    public AutoService(string name) => serviceName = name;
    public void GenerateEvent()
    {
        string message = $"Your car has been repaired and you can pick it up at any time! {serviceName}";
        ServiceEvent.Invoke(message);
    }
}
class EventHandler
{
    private readonly string handlerName;
    public EventHandler(string name)
    {
        handlerName = name;
    }
    public void HandleEvent(string message)
    {
        Console.WriteLine($"Client {handlerName} get a message: {message}");
    }
}
class Program
{
    static void Main()
    {
        AutoService toyota = new ("Toyota");
        AutoService audi = new ("Audi");
        EventHandler eventHandler = new ("Bob");
        toyota.ServiceEvent += eventHandler.HandleEvent;
        audi.ServiceEvent += eventHandler.HandleEvent;
        toyota.GenerateEvent();
        audi.GenerateEvent();
        Console.ReadLine();
    }
}