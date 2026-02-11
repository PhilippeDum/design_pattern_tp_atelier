using design_pattern_tp_atelier.Behavioral.Observers;
using design_pattern_tp_atelier.Creational.Factories;
using design_pattern_tp_atelier.Structural.Decorators;
using Console = System.Console;

Console.WriteLine("--TP Design Pattern--");

ToyFactory factory = new ToyFactory();
factory.AddObserver(new ElfObserver("Elf 1"));
factory.AddObserver(new ElfObserver("Elf 2"));

var toy = factory.CreateToy(Factory.ToyType.Console);
var toy2 = factory.CreateToy(Factory.ToyType.ActionFigure);

Console.WriteLine("\n-Before Decorators-");
Console.WriteLine(toy.GetDescription());
Console.WriteLine(toy2.GetDescription());

toy = new WrappingPaperDecorator(toy);
toy2 = new RibbonDecorator(toy2);
toy2 = new WrappingPaperDecorator(toy2);

Console.WriteLine("\n-After Decorators-");
Console.WriteLine(toy.GetDescription());
Console.WriteLine(toy2.GetDescription());