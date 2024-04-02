using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenShop : MonoBehaviour
{

    [SerializeField] private UI_Shop ui_shop;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Fuck");
        IShopCustomer shopCustomer = other.GetComponent<IShopCustomer>();
        if(shopCustomer != null){

            ui_shop.Show(shopCustomer);

        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Fuck2");
        IShopCustomer shopCustomer = other.GetComponent<IShopCustomer>();

        if (shopCustomer != null)
        {

            ui_shop.Hide();

        }
    }
}
