using design_pattern_tp_atelier.Behavioral.Observers;
using design_pattern_tp_atelier.Creational.Factories;
using design_pattern_tp_atelier.Structural.Decorators;
using Console = System.Console;

Console.WriteLine("--TP Design Pattern--");

Factory factory = new ToyFactory();

var toy = factory.CreateToy(ToyFactory.ToyType.Console);
var toy2 = factory.CreateToy(ToyFactory.ToyType.ActionFigure);

Console.WriteLine("\n-Before Decorators-");
Console.WriteLine(toy.GetDescription());
Console.WriteLine(toy2.GetDescription());

Console.WriteLine("\n-After Decorators-");
toy = new WrappingPaperDecorator(toy);
toy2 = new RibbonDecorator(toy2);
toy2 = new WrappingPaperDecorator(toy2);
Console.WriteLine(toy.GetDescription());
Console.WriteLine(toy2.GetDescription());