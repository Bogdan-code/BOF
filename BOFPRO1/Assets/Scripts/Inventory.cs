using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // behövs för att vi ska kunna se inventoryt i inspectorn i unity
public class Inventory 
{
    [System.Serializable]
    public class Slot
    {
        // vilket föremål som finns i slottet
        public int count; // hur många av det föremålet som finns i slottet
        public int maxAllowed; // antal föremål som är tillåtna i slottet
        public Items.FishType type;

        public Sprite icon; 

        public Slot ()
        {
            // nu ska vi lägga till en constructor i slot funktionen, i constructor kommer vi att ställa in alla våra variabler till deras standardvärde
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

        // nu kommer vi kommer att ta en variabel av firre typen som vi lägger till
        public void AddItem(Items item)
        {
            // nu kommer vi att ställa in så att slot typen lika med typen som vi rattar in
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }
    }

    public List<Slot> slots = new List<Slot>();

    //nu vill vi ska skapa en constructor för vårt inventory, en constructor är en funktion som körs när objektet för funktionen skapas, så när vi skapar vårt inventory kommer den att köra constructorn och ställa in vår slot list
    public Inventory(int numslots) 
    {
        // gå igenom antal föremål vårt inventory har, som vi skickar till funktionen, sedan inuti loopen kan vi skapa en ny slot och lägga till den i slot listen
        for (int i = 0; i < numslots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    // nu ska vi lägga till ett sätt för våra spelare att lägga till firrar i sitt inventory när de tar upp dem
    public void Add(Items item)
    {
        // vi måste söka igenom vårt inventory för alla firrar som är av samma typ som firren vi försöker lägga till
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


