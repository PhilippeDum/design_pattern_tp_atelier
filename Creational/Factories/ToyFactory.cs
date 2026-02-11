using design_pattern_tp_atelier.Behavioral.Observers;

namespace design_pattern_tp_atelier.Creational.Factories;

public class ToyFactory : Factory
{
    private Dictionary<ToyType, Factory> _factories = new()
    {
        [ToyType.Console] = new ConsoleFactory(),
        [ToyType.ActionFigure] = new ActionFigureFactory(),
    };
    private List<IObserver> _observers = new List<IObserver>();

    public override IToy CreateToy()
    {
        return null;
    }

    public override IToy CreateToy(ToyType type)
    {
        _factories.TryGetValue(type, out var toy);

        if (toy == null) return null;
        
        IToy newToy = toy.CreateToy();
        
        NotifyObservers($"A new toy was created: {newToy.GetDescription()} !!");

        return newToy;
    }
    
    public void AddObserver(IObserver observer) => _observers.Add(observer);
    public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

    public void NotifyObservers(string message)
    {
        foreach (var observer in _observers)
            observer.Update(message);
    }
}