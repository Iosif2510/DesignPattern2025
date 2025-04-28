

public class InheritedSingleton : GenericSingleton<InheritedSingleton>
{
    public int someData2 = 5;
    protected override void Init()
    {
        
    }
}