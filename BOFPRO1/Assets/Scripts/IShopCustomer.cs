using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer 
{
    void BoughtItem(Item.Buyable_Items itemType);
    bool TrySpendMoney(int goldAmount);


}
    