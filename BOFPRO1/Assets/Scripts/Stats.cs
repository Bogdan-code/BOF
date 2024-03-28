using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{

    [SerializeField]
    private float startCash;

    public TextMeshProUGUI text;



    
    void Start()
    {
        pengar.startGame(startCash);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = pengar.money.ToString();
    }
}
