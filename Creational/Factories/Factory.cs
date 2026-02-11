namespace design_pattern_tp_atelier.Creational.Factories;

public abstract class Factory : IToy
{
    public enum ToyType
    {
        PS5,
        PS4,
        ActionFigure,
    }
    
    public abstract IToy CreateToy();
    public string GetDescription() => "Description...";
}