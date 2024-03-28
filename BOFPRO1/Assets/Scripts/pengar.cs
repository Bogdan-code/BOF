using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;

public static class pengar
{

    public static float money;


    public static void startGame(float startingCash)
    {
        money = startingCash;
    }

    public static void RemoveMoney(float Cost)
    {
            money -= Cost;
    }

     
    
}
