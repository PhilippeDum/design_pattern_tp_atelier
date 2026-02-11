namespace design_pattern_tp_atelier.Behavioral.Observers;

public class ElfObserver : IObserver
{
    private readonly string _name;

    public ElfObserver(string name)
    {
        _name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{_name} received: {message}");
    }
}