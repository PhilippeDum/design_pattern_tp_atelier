namespace design_pattern_tp_atelier.Creational.Factories;

public class ToyFactory : Factory
{
    private Dictionary<ToyType, Factory> _factories = new()
    {
        [ToyType.Console] = new ConsoleFactory(),
        [ToyType.ActionFigure] = new ActionFigureFactory(),
    };

    public override IToy CreateToy()
    {
        return null;
    }

    public override IToy CreateToy(ToyType type)
    {
        _factories.TryGetValue(type, out var toy);

        if (toy == null) return null;
        
        return toy.CreateToy();
    }
}