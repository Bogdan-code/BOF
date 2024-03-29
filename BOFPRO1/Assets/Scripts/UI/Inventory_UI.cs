using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;

    public Player player;

    public List<Slots_UI> slots = new List<Slots_UI>();

    void Update()
    {
        // vi kommer att få spelarnas input för att öppna och stänga vårt inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    // nu vill vi toggla vårt inventory
    public void ToggleInventory()
    {
        // vi vill kolla det nuvarande läget för vårt inventory, är den på? eller är den av?
        if(!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }

        // vi kommer att behöva ställa in ui för att visa spelaren en korrekt representation av deras inventory, så varje gång vi öppnar ui bör vi kontrollera inventoryt och göra ändringar i ui om det behövs
        void Setup()
        {
            // vi ska kontrollera om inventoryt och inventory_ui har samma antal slots, om de har det kan vi fortsätta med att ställa in vårt inventory
            if (slots.Count == player.inventory.slots.Count)
            {
                // gå igenom alla slots och sätt upp var och en
                for (int i = 0; i < slots.Count; i++)
                {
                    // kontrollera om slotten i inventoryt är fylld, om type inte är inget, har vi ett item i vårt inventory
                    if (player.inventory.slots[i].type != Items.FishType.None)
                    {

                    }
                }
            }
        }
    }
}
