using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFuckingFishing : MonoBehaviour
{
    public GameObject fishingUi;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fishingUi.SetActive(true);


        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fishingUi.SetActive(false);
        }

    }
}
