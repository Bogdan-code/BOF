using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IShopCustomer
{
    public Inventory inventory;

    

    public void BoughtItem(Item.Buyable_Items itemType)
    {


    }

    public bool TrySpendMoney(int spendMoneyAmount)
    {
        if(pengar.money >= spendMoneyAmount) { pengar.money -= spendMoneyAmount; return true; }
        else { return false; }

    }

    private void Awake()
    {
        inventory = new Inventory(21);
    }
}
