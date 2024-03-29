using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public FishType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>(); // spelaren g�r in i itemet

        if (player)
        {
            player.inventory.Add(type); // l�gg till itemet till spelaren
            Destroy(this.gameObject); // ta bort itemet fr�n sk�rmen
        }
    }

    public enum FishType
    {
        None, Samlon
    }
}
