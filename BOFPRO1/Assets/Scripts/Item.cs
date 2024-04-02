using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum Buyable_Items
    {
        Bait_1,
        Bait_2,
        Bait_3,
        Fishingrod_1,
        Fishingrod_2,
        Fishingrod_3
    }

    public static int GetCost(Buyable_Items items)
    {
        switch (items)
        {
            default:
            case Buyable_Items.Bait_1: return 15;
            case Buyable_Items.Bait_2: return 50;
            case Buyable_Items.Bait_3: return 235;
            case Buyable_Items.Fishingrod_1: return 10;
            case Buyable_Items.Fishingrod_2: return 200;
            case Buyable_Items.Fishingrod_3: return 500;
        }
    }

    public static Sprite GetSprite(Buyable_Items itemType)
    {
        switch (itemType)
        {
            default:
            case Buyable_Items.Bait_1: return GameAssets.i.Bait_1;
            case Buyable_Items.Bait_2: return GameAssets.i.Bait_2;
            case Buyable_Items.Bait_3: return GameAssets.i.Bait_3;

            case Buyable_Items.Fishingrod_1: return GameAssets.i.Fishingrod_1;
            case Buyable_Items.Fishingrod_2: return GameAssets.i.Fishingrod_2;
            case Buyable_Items.Fishingrod_3: return GameAssets.i.Fishingrod_3;
        }


    }
}
