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
        itemIcon.color = new Color(1, 1, 1, 1); // detta �r n�dv�ndigt eftersom vi kommer att g�ra ikon bilden genomskinlig, s� att slotten inte har n�gra bilder synliga n�r den �r tom
        quantityText.text = slot.count.ToString();
    }

    public void SetEmpty()
    {
        itemIcon.sprite=null; // n�r den �r satt till null visar den bara en vit fyrkant
        itemIcon.color = new Color(1, 1, 1, 0); // sista valuen kallas f�r alpha value och n�r den �r satt till noll kommer imagen vara osynlig
        quantityText.text = ""; // stringen �r tom eftersom vi inte vill visa texten om vi inte har n�got i slotten
    }
}
