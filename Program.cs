using design_pattern_tp_atelier.Behavioral.Observers;
using design_pattern_tp_atelier.Creational.Factories;
using design_pattern_tp_atelier.Structural.Decorators;
using Console = System.Console;

List<IToy> toys = new List<IToy>();

ToyFactory factory = new ToyFactory();

factory.AddObserver(new ElfObserver("Elf 1"));
factory.AddObserver(new ElfObserver("Elf 2"));

var toy = factory.CreateToy(Factory.ToyType.PS5);
var toy2 = factory.CreateToy(Factory.ToyType.ActionFigure);

toys.Add(toy);
toys.Add(toy2);

Console.WriteLine("\n-Before Decorators-");
Console.WriteLine(toy.GetDescription());
Console.WriteLine(toy2.GetDescription());

toy = new WrappingPaperDecorator(toy);
toy2 = new RibbonDecorator(toy2);
toy2 = new WrappingPaperDecorator(toy2);

Console.WriteLine("\n-After Decorators-");
Console.WriteLine(toy.GetDescription());
Console.WriteLine(toy2.GetDescription());

Menu();

void Menu()
{
    int option = 1;
    while (option > 0)
    {
        Console.WriteLine("\n--TP Design Pattern--");
        Console.WriteLine("1. Show all toys");
        Console.WriteLine("2. Add toy");
        Console.WriteLine("3. Show Observer Log");
        Console.WriteLine("0. Quit");
        Console.Write("Option: ");
        option = int.Parse(Console.ReadLine());

        if (option < 0 || option > 3) continue;

        if (option == 0)
        {
            Console.WriteLine("Quitting...");
            break;
        }

        switch (option)
        {
            case 1:
                ShowAllToys();
                break;
            case 2:
                AddToy();
                break;
            case 3:
                ShowObserverLog();
                break;
            default:
                return;
        }
    }
}

void ShowAllToys()
{
    Console.WriteLine("1. Show all toys");
    foreach (var toy in toys)
    {
        Console.WriteLine(toy.GetDescription());
    }
}

void AddToy()
{
    Console.WriteLine("2. Add toy");
    Console.WriteLine("> 0. PS5");
    Console.WriteLine("> 1. PS4");
    Console.WriteLine("> 2. ActionFigure");
    Console.Write("Enter a toy type index : ");
    int typeIndex = int.Parse(Console.ReadLine());
    
    if (typeIndex < 0 || typeIndex > factory.Observers.Count - 1) return;

    Factory.ToyType type = typeIndex switch
    {
        0 => Factory.ToyType.PS5,
        1 => Factory.ToyType.PS4,
        2 => Factory.ToyType.ActionFigure,
        _ => Factory.ToyType.PS5
    };
    
    var toy = factory.CreateToy(type);
    toys.Add(toy);
    Console.WriteLine($"New toy add: {toy.GetDescription()}");
}

void ShowObserverLog()
{
    Console.WriteLine("3. Show Observer Log");
    for (var i = 0; i < factory.Observers.Count; i++)
    {
        var observer = factory.Observers[i];
        Console.WriteLine($"{i}. {(observer as ElfObserver).Name}");
    }

    Console.Write("Enter a toy type index : ");
    int observerIndex = int.Parse(Console.ReadLine());
    
    if (observerIndex < 0 || observerIndex > factory.Observers.Count - 1) return;

    IObserver selectedObserver = factory.Observers[observerIndex];
    for (int i = 0; i < selectedObserver.Logs.Count; i++)
    {
        Console.WriteLine($"{i}. {selectedObserver.Logs[i]}");
    }
}