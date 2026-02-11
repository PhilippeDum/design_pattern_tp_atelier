using design_pattern_tp_atelier.Creational.Factories;

namespace design_pattern_tp_atelier.Structural.Decorators;

public class RibbonDecorator : ToyDecorator
{
    public RibbonDecorator(IToy toy) : base(toy) {}

    public override string GetDescription()
    {
        return base.GetDescription() + ", with a ribbon";
    }
}