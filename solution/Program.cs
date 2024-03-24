// See https://aka.ms/new-console-template for more information

using APBD_3;

public class Program 
{
    public static void Main(string[] args)
    {
        //Stworzenie kontenera danego typu
        Container container = new GasContainer(6, 700, 4, 18, 10_000, 3);
        Console.WriteLine(container);
        
        
        //Załadowanie ładunku do danego kontenera
        container.Load(1_000);

        ContainerShip containerShip = new ContainerShip(10, 90, 50_000);
        
        //Załadowanie kontenera na statek
        containerShip.addContainer(container);
        
        //Załadowanie listy kontenerów na statek
        List<Container> containerList = new List<Container>();
        containerList.Add(new LiquidContainer(6, 700, 4, 18, 10_000));
        containerList.Add(new RefrigeratedContainer(6, 700, 4, 18, 10_000, 14, RefrigeratedContainer.ContainedType.Processed));
        containerList.Add(new GasContainer(8, 900, 5, 16, 15_000, 2));
        foreach (Container c in containerList) 
        {
            containerShip.addContainer(c);
        }
        
        //Usunięcie kontenera ze statku
        containerShip.removeContainer(container);
        
        //Rozładowanie kontenera
        foreach (Container c in containerShip.Containers)
        {
            containerShip.removeContainer(c);
        }
        
        //Zastąpienie kontenera na statku o danym numerze innym kontenerem
        Container toBeReplacedContainer =
            new RefrigeratedContainer(6, 700, 4, 18, 10_000, 14, RefrigeratedContainer.ContainedType.Meat);

        Container replacingContainer =
            new LiquidContainer(5, 900, 7, 20, 18_000);
        
        containerShip.addContainer(toBeReplacedContainer);
        
        foreach (Container c in containerShip.Containers)
        {
            if (c.SerialNumber.Equals(replacingContainer.SerialNumber))
            {
                containerShip.removeContainer(c);
                break;
            }
        }
        containerShip.addContainer(replacingContainer);
        
        // Możliwość przeniesienie kontenera między dwoma statkami
        ContainerShip containerShip1 = new ContainerShip(8, 150, 100_000);
        containerShip.removeContainer(replacingContainer);
        containerShip1.addContainer(replacingContainer);
        
        //Wypisanie informacji o danym kontenerze
        Console.WriteLine(replacingContainer);
        
        //Wypisanie informacji o danym statku i jego ładunku
        Console.WriteLine(containerShip);
        foreach (Container c in containerShip.Containers)
        {
            Console.WriteLine(c);
        }
        
    }
}