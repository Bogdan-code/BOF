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
    
    void Start()
    {
        pengar.startGame(startCash);
        
    }

    // Update is called once per frame
    void Update()
    {
        pengarText.text = "Wallet: " + pengar.money.ToString() + "$";


    }

   
}
