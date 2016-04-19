public class Program
{
    public static void Main(string[] args)
    {
        string carName = args[0];
        
        AutoFactory f = new AutoFactory();
        IAuto c = f.CreateInstance(carName);
        
        c.TurnOn();
        c.TurnOff();
    }
}

public class AutoFactory
{
    private Dictionary<string, Type> _autos;
    
    public AutoFactory()
    {
        LoadTypes();
    }
    
    public IAuto CreateInstance(string carName)
    {
        Type t = GetTypeFor(carName);
        if (t == null)
            return new NullAuto(); //NULL Object Pattern
        return Activator.CreateInstance(t) as IAuto; //Reflection & safe typecast
    }
    
    protected GetTypeFor(string carName)
    {
        foreach (var a in _autos)
            if(a.Key.Contains(carName))
                return _autos[a.Key];
        return null;
    }
    
    protected LoadTypes()
    {
        _autos = new Dictionary<string, Type>();
        //More Reflection - pretty common in .NET factories, just an implementation choice
        var types = Assembly.GetExecutingAssembly().GetTypes();
        foreach(var t in types)
            if(t.GetInterface(typeof(IAuto).ToString()) != null)
                _autos.Add(t.Name.ToLower(), t);
    }
}