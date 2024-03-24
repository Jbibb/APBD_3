namespace APBD_3;

public class GasContainer : Container, IHazardNotifier
{
    private double pressure;
    
    public GasContainer(int height, double weight, double width, double depth, double maxLoad) : base(height, weight, width, depth, maxLoad)
    {
        
    }

    public void NotifyOfDanger(string message, string serialNumber)
    {
        Console.WriteLine(serialNumber + ": " + message);
    }
}