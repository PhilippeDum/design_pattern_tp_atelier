namespace design_pattern_tp_atelier.Creational.Factories;

public class ConsoleFactory : Factory
{
    public override IToy CreateToy()
    {
        return new Console();
    }
}