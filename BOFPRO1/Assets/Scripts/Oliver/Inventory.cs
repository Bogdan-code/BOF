using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // beh�vs f�r att vi ska kunna se inventoryt i inspectorn i unity
public class Inventory 
{
    [System.Serializable]
    public class Slot
    {
        // vilket f�rem�l som finns i slottet
        public int count; // hur m�nga av det f�rem�let som finns i slottet
        public int maxAllowed; // antal f�rem�l som �r till�tna i slottet
        public Items.FishType type;

        public Sprite icon; 

        public Slot ()
        {
            // nu ska vi l�gga till en constructor i slot funktionen, i constructor kommer vi att st�lla in alla v�ra variabler till deras standardv�rde
            type = Items.FishType.None;
            count = 0;
            maxAllowed = 2;
        }

        public bool CanAddItem()
        {
            if (count < maxAllowed)
            {
                return true;
            }
            return false;
        }

        // nu kommer vi kommer att ta en variabel av firre typen som vi l�gger till
        public void AddItem(Items item)
        {
            // nu kommer vi att st�lla in s� att slot typen lika med typen som vi rattar in
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }
    }

    public List<Slot> slots = new List<Slot>();

    //nu vill vi ska skapa en constructor f�r v�rt inventory, en constructor �r en funktion som k�rs n�r objektet f�r funktionen skapas, s� n�r vi skapar v�rt inventory kommer den att k�ra constructorn och st�lla in v�r slot list
    public Inventory(int numslots) 
    {
        // g� igenom antal f�rem�l v�rt inventory har, som vi skickar till funktionen, sedan inuti loopen kan vi skapa en ny slot och l�gga till den i slot listen
        for (int i = 0; i < numslots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    // nu ska vi l�gga till ett s�tt f�r v�ra spelare att l�gga till firrar i sitt inventory n�r de tar upp dem
    public void Add(Items item)
    {
        // vi m�ste s�ka igenom v�rt inventory f�r alla firrar som �r av samma typ som firren vi f�rs�ker l�gga till
        foreach(Slot slot in slots) 
        {
            if (slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if(slot.type == Items.FishType.None)
            {
                slot.AddItem(item);
                return;
            }
        }
    }
}


