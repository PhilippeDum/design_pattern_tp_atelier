using design_pattern_tp_atelier.Behavioral.Observers;
using design_pattern_tp_atelier.Creational.Factories;
using design_pattern_tp_atelier.Structural.Decorators;
using Console = System.Console;

List<IToy> toys = new List<IToy>();

ToyFactory factory = new ToyFactory();

factory.AddObserver(new ElfObserver("Elf 1"));
factory.AddObserver(new ElfObserver("Elf 2"));

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
        Console.WriteLine("4. Add decoration");
        Console.WriteLine("0. Quit");
        Console.Write("Option: ");
        option = int.Parse(Console.ReadLine());

        if (option < 0 || option > 4) continue;

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
            case 4:
                AddDecoration();
                break;
            default:
                return;
        }
    }
}

void ShowAllToys()
{
    Console.WriteLine("\n1. Show all toys");
    foreach (var toy in toys)
    {
        Console.WriteLine(toy.GetDescription());
    }
}

void AddToy()
{
    Console.WriteLine("\n2. Add toy");
    Console.WriteLine("> 0. PS5");
    Console.WriteLine("> 1. PS4");
    Console.WriteLine("> 2. ActionFigure");
    Console.Write("Enter a toy type index : ");
    int typeIndex = int.Parse(Console.ReadLine());
    
    if (typeIndex < 0 || typeIndex > 2) return;

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
    Console.WriteLine("\n3. Show Observer Log");
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

void AddDecoration()
{
    Console.WriteLine("\n4. Add decoration");

    for (int i = 0; i < toys.Count; i++)
    {
        Console.WriteLine($"{i}. {toys[i].GetDescription()}");
    }
    Console.Write("Enter a toy index : ");
    int toyIndex = int.Parse(Console.ReadLine());
    
    if (toyIndex < 0 || toyIndex > toys.Count - 1) return;
    
    Console.WriteLine("> 0. Wrapping Paper");
    Console.WriteLine("> 1. Ribbon");
    
    Console.Write("Enter a decoration index : ");
    int decorationIndex = int.Parse(Console.ReadLine());
    
    IToy toy = toys[toyIndex];
    toy = decorationIndex switch
    {
        0 => new WrappingPaperDecorator(toy),
        1 => new RibbonDecorator(toy),
        _ => toy
    };
    toys[toyIndex] = toy;
    Console.WriteLine($"Toy updated: {toy.GetDescription()}");
}