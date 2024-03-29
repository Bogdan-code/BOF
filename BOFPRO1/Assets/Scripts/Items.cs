using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public FishType type;
    public Sprite icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player not found in the scene!");
        }

        if (collision.CompareTag("Player"))
        {
            player.inventory.Add(this); // lägg till itemet till spelaren
            Destroy(this.gameObject); // ta bort itemet från skärmen
        }
    }

    public enum FishType
    {
        None, Salmon
    }
}
