using System.Data;

namespace APBD_3;

public class GasContainer : Container, IHazardNotifier
{
    private double pressure;
    
    public GasContainer(int height, double weight, double width, double depth, double maxLoad, double pressure) : base(height, weight, width, depth, maxLoad)
    {
        this.SerialNumber = "KON-G-" + Container.ContainerCount;
        
        this.pressure = pressure;
    }

    public void EmptyLoad()
    {
        base.LoadWeight = 0.05 * base.LoadWeight;
    }

    public void NotifyOfDanger(string message, string serialNumber)
    {
        Console.WriteLine(serialNumber + ": " + message);
    }

    public override string ToString()
    {
        return "Gas " + base.ToString() + " Pressure: " + pressure + " atm";
    }
}