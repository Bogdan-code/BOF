using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static void AddMoney(float Cost)
    {
        money += Cost;
    }



}
