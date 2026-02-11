using design_pattern_tp_atelier.Creational.Factories;

namespace design_pattern_tp_atelier.Structural.Decorators;

public abstract class ToyDecorator : IToy
{
    protected readonly IToy _toy;
    
    protected ToyDecorator(IToy toy) => _toy = toy;
    
    public virtual string GetDescription() => _toy.GetDescription();
}