using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Shop : MonoBehaviour
{

    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    float activeTime = 0.5f;
    float removeTime;
    public GameObject noTxt;
    bool removeTimerActive;

    private void Update()
    {
        if(removeTimerActive)
            if (Time.time >= removeTime) { 
                noTxt.SetActive(false);
                removeTimerActive = false;
            }
    }

    public void Awake()
    {

        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);


    }

    private void Start()
    {
        CreateItemButton(Item.Buyable_Items.Fishingrod_1, Item.GetSprite(Item.Buyable_Items.Fishingrod_1), "Fishingrod 1", Item.GetCost(Item.Buyable_Items.Fishingrod_1), 0);
        CreateItemButton(Item.Buyable_Items.Fishingrod_2, Item.GetSprite(Item.Buyable_Items.Fishingrod_2), "Fishingrod 2", Item.GetCost(Item.Buyable_Items.Fishingrod_2), 1);
        CreateItemButton(Item.Buyable_Items.Fishingrod_3, Item.GetSprite(Item.Buyable_Items.Fishingrod_3), "Fishingrod 3", Item.GetCost(Item.Buyable_Items.Fishingrod_3), 2);
        noTxt.SetActive(false);

        Hide();

    }

    private void CreateItemButton(Item.Buyable_Items itemType,Sprite Itemprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 70f;
        shopItemRectTransform.anchoredPosition = new Vector2 (0, -shopItemHeight * positionIndex);
        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);

        shopItemTransform.Find("itemImage").GetComponent<Image>().GetComponent<Image>().sprite = Itemprite;

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            TryBuyItem(itemType);
        };

    }
    private void TryBuyItem(Item.Buyable_Items itemType)
    {
        if (shopCustomer.TrySpendMoney(Item.GetCost(itemType)))
        {
            shopCustomer.BoughtItem(itemType);
        }
        else
        {
            Debug.Log("not Enough Money");
            removeTimerActive = true;
            removeTime = Time.time + activeTime;
            noTxt.SetActive(true);
        }


    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
