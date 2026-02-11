namespace design_pattern_tp_atelier.Creational.Factories;

public class ActionFigure : IToy
{
    public void GetDescription()
    {
        System.Console.WriteLine("C'est une figurine");
    }
}