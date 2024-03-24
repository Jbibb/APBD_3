namespace APBD_3;

public class ContainerShip
{
    private List<Container> containers = new List<Container>();
    private int maxSpeed;
    private int maxContainerAmount;
    private double heldWeight = 0;
    private int maxHeldWeight;

    public ContainerShip(int maxSpeed, int maxContainerAmount, int maxHeldWieght)
    {
        this.maxSpeed = maxSpeed;
        this.maxContainerAmount = maxContainerAmount;
        this.maxHeldWeight = maxHeldWieght;
    }

    public List<Container> Containers
    {
        get { return new List<Container>(containers); }
    }

    public void addContainer(Container container)
    {
        if(containers.Count >= maxContainerAmount)
            Console.WriteLine("Maximum amount of held containers met");
        else if(container.LoadWeight + this.heldWeight >= maxHeldWeight)
            Console.WriteLine("Maximum weight of carried load met");
        else
        {
            containers.Add(container);
            heldWeight += container.LoadWeight;
            heldWeight += container.Weight;
        }
    }

    public void removeContainer(Container container)
    {
        if (containers.Contains(container))
        {
            containers.Remove(container);
            heldWeight -= container.LoadWeight;
            heldWeight -= container.Weight;
        }
    }

    public override string ToString()
    {
        return "Container Ship\tContainers: " + containers.Count + "/" + maxContainerAmount + "\tCarried weight: " +
               heldWeight + "/" + maxHeldWeight + " kg\tMax speed: " + maxSpeed + " knots";
    }
}