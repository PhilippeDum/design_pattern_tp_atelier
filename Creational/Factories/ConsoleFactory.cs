namespace design_pattern_tp_atelier.Creational.Factories;

public class ConsoleFactory : Factory
{
    private readonly ToyType _toyType;
    
    public ConsoleFactory(ToyType toyType)
    {
        _toyType = toyType;
    }
    
    public override IToy CreateToy()
    {
        switch (_toyType)
        {
            case ToyType.PS5:
                return new Playstation5();
            case ToyType.PS4:
                return new Playstation4();
        }
        return null;
    }
}