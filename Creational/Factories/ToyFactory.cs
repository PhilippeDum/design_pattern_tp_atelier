using design_pattern_tp_atelier.Behavioral.Observers;

namespace design_pattern_tp_atelier.Creational.Factories;

public class ToyFactory
{
    private Dictionary<Factory.ToyType, Factory> _factories = new()
    {
        [Factory.ToyType.Console] = new ConsoleFactory(),
        [Factory.ToyType.ActionFigure] = new ActionFigureFactory(),
    };
    private List<IObserver> _observers = new List<IObserver>();

    public IToy CreateToy(Factory.ToyType type)
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