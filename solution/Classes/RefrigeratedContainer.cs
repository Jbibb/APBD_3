namespace APBD_3;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public enum ContainedType
    {
        Meat,
        FruitsAndVegetables,
        Processed
    }

    private ContainedType containedType;

    private Dictionary<String, double> storage;
    
    private double temperature;
    
    
    
    public RefrigeratedContainer(int height, double weight, double width, double depth, double maxLoad, double temperature, ContainedType containedType) : base(height, weight, width, depth, maxLoad)
    {
        this.SerialNumber = "KON-R-" + Container.ContainerCount;
        this.temperature = temperature;
        this.containedType = containedType;
    }

    public void Load(double loadWeight, ContainedType containedType, String name, double requiredTemperature)
    {
        if(containedType != this.containedType)
            NotifyOfDanger("Attempted to load product type not matching with the containers type", base.SerialNumber);
        if(requiredTemperature < temperature)
            NotifyOfDanger("Attempted to load product which required temperature is not met in the container", base.SerialNumber);
        base.Load(loadWeight);
        if (storage.ContainsKey(name))
            storage.Add(name, loadWeight + storage[name]);
        else 
            storage.Add(name, loadWeight);
    }

    public void EmptyLoad()
    {
        base.EmptyLoad();
        storage.Clear();
    }
    
    

    public void NotifyOfDanger(string message, string serialNumber)
    {
        Console.WriteLine(serialNumber + ": " + message);
    }

    public override string ToString()
    {
        return "Refrigerated " + base.ToString() + " Contained type: " + containedType + " Temperature: " + temperature + "\u00b0C";
    }
}