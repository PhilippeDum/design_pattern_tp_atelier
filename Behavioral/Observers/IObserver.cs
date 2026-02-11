namespace design_pattern_tp_atelier.Behavioral.Observers;

public interface IObserver
{
    public List<string> Logs { get; set; }
    public void Update(string message);
}