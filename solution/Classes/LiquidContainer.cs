namespace APBD_3;

public class LiquidContainer : Container, IHazardNotifier
{
    private Boolean containsDangerousLoad = false;
    
    public LiquidContainer(int height, double weight, double width, double depth, double maxLoad) : base(height, weight, width, depth, maxLoad)
    {
        this.SerialNumber = "KON-L-" + Container.ContainerCount;
    }
    
    

    public void Load(double loadWeight)
    {
        if (containsDangerousLoad) 
        {
            if (base.LoadWeight + loadWeight > 0.5 * base.MaxLoad)
            {
                NotifyOfDanger("Attempted to fill more than half of a liquid container carrying dangerous load", base.SerialNumber);
                return;
            }
        }
        else
        {
            if (base.LoadWeight + loadWeight > 0.9 * base.MaxLoad)
            {
                NotifyOfDanger("Attempted to fill more than 90% of a liquid container", base.SerialNumber);
                return;
            }
        } 
        base.Load(loadWeight);
    }

    public void NotifyOfDanger(string message, string serialNumber)
    {
        Console.WriteLine(serialNumber + ": " + message);
    }

    public override string ToString()
    {
        return "Liquid " + base.ToString() + (this.containsDangerousLoad ? " Carries dangerous load" : " Does not carry dangerous load");
    }
}