using design_pattern_tp_atelier.Creational.Factories;
using Console = System.Console;

Console.WriteLine("--TP Design Pattern--");

Factory factory = new ToyFactory();
var toy = factory.CreateToy(ToyFactory.ToyType.Console);
toy.GetDescription();

toy = factory.CreateToy(ToyFactory.ToyType.ActionFigure);
toy.GetDescription();