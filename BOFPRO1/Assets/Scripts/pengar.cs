using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pengar : MonoBehaviour
{
    static public float para = 100;

    public TextMeshProUGUI paraText;

    // Start is called before the first frame update
    public  void RemovePara(float Cost)
    {
        para -= Cost;
    }

    public  void AddPara(float MerPara)
    {
        para += MerPara;
    }

    // Update is called once per frame
    void Start()
    {
        paraText.text = "Money: "+ para.ToString();
    }
}
