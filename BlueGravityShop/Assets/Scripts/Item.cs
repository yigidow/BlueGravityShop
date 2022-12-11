using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public Button itemButton;

    public int buyValue;
    public int sellValue;
    public string clotheType;

    public Sprite itemImage;

    public Image itemImageShown;
    public TMP_Text buyPrice;
    public TMP_Text sellPrice;

    public bool isEquiped ;

    void Awake()
    {
        buyPrice.text = buyValue.ToString() + ("$");
        sellPrice.text = sellValue.ToString() + ("$");
        itemImageShown.sprite = itemImage;
        SetButtonFunctions();
    }

// Update is called once per frame
    void Update()
    {
    }
    public void EquipItem() 
    {
        Debug.Log("equip");
        isEquiped = true;
    }
    
    public void BuyItem()
    {
        Debug.Log("buy");
    }
    public void SellItem()
    {
        Debug.Log("sell");
    }

    public void SetButtonFunctions()
    {
        if (itemButton.gameObject.transform.parent.name == ("InventoryScreen"))
        {
            itemButton.onClick.AddListener(delegate { EquipItem(); });
        }
        else if (itemButton.gameObject.transform.parent.name == ("ShopBuyScreen"))
        {
            itemButton.onClick.AddListener(delegate { BuyItem(); });
        }
        else if (itemButton.gameObject.transform.parent.name == ("ShopSellScreen"))
        {
            itemButton.onClick.AddListener(delegate { SellItem(); });
        }
    }
}
