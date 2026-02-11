namespace design_pattern_tp_atelier.Behavioral.Observers;

public class Subject
{
    private List<IObserver> _observers = new List<IObserver>();
    
    public void AddObserver(IObserver observer) => _observers.Add(observer);
    public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

    public void NotifyObservers(string message)
    {
        foreach (var observer in _observers)
            observer.Update(message);
    }
}