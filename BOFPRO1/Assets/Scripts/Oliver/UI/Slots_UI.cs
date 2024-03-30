using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slots_UI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;

    public void SetItem(Inventory.Slot slot)
    {
        itemIcon.sprite = slot.icon;
        itemIcon.color = new Color(1, 1, 1, 1); // detta är nödvändigt eftersom vi kommer att göra ikon bilden genomskinlig, så att slotten inte har några bilder synliga när den är tom
        quantityText.text = slot.count.ToString();
    }

    public void SetEmpty()
    {
        itemIcon.sprite=null; // när den är satt till null visar den bara en vit fyrkant
        itemIcon.color = new Color(1, 1, 1, 0); // sista valuen kallas för alpha value och när den är satt till noll kommer imagen vara osynlig
        quantityText.text = ""; // stringen är tom eftersom vi inte vill visa texten om vi inte har något i slotten
    }
}
