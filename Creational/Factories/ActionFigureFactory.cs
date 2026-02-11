namespace design_pattern_tp_atelier.Creational.Factories;

public class ActionFigureFactory : Factory
{
    public override IToy CreateToy()
    {
        return new ActionFigure();
    }

    public override IToy CreateToy(ToyType type)
    {
        return new ActionFigure();
    }
}