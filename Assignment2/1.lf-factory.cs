public class Program
{
    public static void Main(string[] args)
    {
        string carName = args[0];
        
        IAuto car = GetCar(carName);
        car.TurnOn();
        car.TurnOff();
    }
    
    private static IAuto GetCar(string carName)
    {
        switch (carName)
        {
            case "bmw":
                return new BMWZ4();
            case "mini":
                return new MiniCooper();
            case "vw":
                return new Golf();
            default:
                return new NullCar(); //NULL Object Pattern
        }
    }
}