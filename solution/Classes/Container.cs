namespace APBD_3;

public abstract class Container
{
    private double loadWeight = 0;
    private int height;
    private double weight;
    private double width, depth;
    private String serialNumber;
    private double maxLoad;

    public Container(int height, double weight, double width, double depth, double maxLoad)
    {
        this.height = height;
        this.weight = weight;
        this.width = width;
        this.depth = depth;
        this.maxLoad = maxLoad;
    }

    public void EmptyLoad()
    {
        loadWeight = 0;
    }

    public void Load(double loadWeight)
    {
        if (this.loadWeight + loadWeight > maxLoad)
            throw new OverfillException();
        this.loadWeight += loadWeight;
    }

    public double LoadWeight
    {
        get { return loadWeight; }
    }

    public string SerialNumber
    {
        get { return serialNumber; }
    }

    public double MaxLoad
    {
        get { return MaxLoad; }
    }

}