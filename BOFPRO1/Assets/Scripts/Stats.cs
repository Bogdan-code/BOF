using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class Stats : MonoBehaviour
{

    [SerializeField] private float startCash;


    public TextMeshProUGUI pengarText;
    private float time1;
    
    void Start()
    {
        pengar.startGame(startCash);
        
    }

    // Update is called once per frame
    void Update()
    {
        pengarText.text = pengar.money.ToString();

        if (Input.GetKeyDown(KeyCode.F))
        {
            time1 = Time.time;

            if (time1 == 1)
            {
                Debug.Log("Lol1");
            }
            if (time1 == 2)
            {
                Debug.Log("Lol2");
            }
        }
    
    }

   
}
