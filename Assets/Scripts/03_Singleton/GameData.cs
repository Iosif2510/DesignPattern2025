public static class GameData
{
    private static float gameStatic1;
    
    public static float GameStatic1
    {
        get => gameStatic1;
        set => gameStatic1 = value;
    }
    
    public static void ResetGameData()
    {
        gameStatic1 = 0;
    }
}