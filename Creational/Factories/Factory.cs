namespace design_pattern_tp_atelier.Creational.Factories;

public abstract class Factory : IToy
{
    public enum ToyType
    {
        Console,
        ActionFigure,
    }
    
    public abstract IToy CreateToy();
    public abstract IToy CreateToy(ToyType type);
    public void GetDescription() { }
}