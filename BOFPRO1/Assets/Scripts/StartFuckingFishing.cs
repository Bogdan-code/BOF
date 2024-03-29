using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFuckingFishing : MonoBehaviour
{
    public GameObject fishingUi;
    public static bool isInFishingPlace = false;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInFishingPlace = true;
            

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInFishingPlace = false;

        }

    }
}
