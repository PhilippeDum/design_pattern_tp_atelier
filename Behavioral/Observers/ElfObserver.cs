namespace design_pattern_tp_atelier.Behavioral.Observers;

public class ElfObserver : IObserver
{
    private readonly string _name;
    public string Name => _name;
    public List<string> Logs { get; set; } = new List<string>();

    public ElfObserver(string name)
    {
        _name = name;
    }
    
    public void Update(string message)
    {
        Console.WriteLine($"{_name} received: {message}");
        Logs.Add(message);
    }
}