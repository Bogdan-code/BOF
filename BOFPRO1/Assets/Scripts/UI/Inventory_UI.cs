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
        // vi kommer att f� spelarnas input f�r att �ppna och st�nga v�rt inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    // nu vill vi toggla v�rt inventory
    public void ToggleInventory()
    {
        // vi vill kolla det nuvarande l�get f�r v�rt inventory, �r den p�? eller �r den av?
        if(!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }

        // vi kommer att beh�va st�lla in ui f�r att visa spelaren en korrekt representation av deras inventory, s� varje g�ng vi �ppnar ui b�r vi kontrollera inventoryt och g�ra �ndringar i ui om det beh�vs
        void Setup()
        {
            // vi ska kontrollera om inventoryt och inventory_ui har samma antal slots, om de har det kan vi forts�tta med att st�lla in v�rt inventory
            if (slots.Count == player.inventory.slots.Count)
            {
                // g� igenom alla slots och s�tt upp var och en
                for (int i = 0; i < slots.Count; i++)
                {
                    // kontrollera om slotten i inventoryt �r fylld, om type inte �r inget, har vi ett item i v�rt inventory
                    if (player.inventory.slots[i].type != Items.FishType.None)
                    {

                    }
                }
            }
        }
    }
}
