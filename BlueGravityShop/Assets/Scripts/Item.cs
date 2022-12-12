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

    public bool isEquiped;
    public bool isBuying;
    public bool isSelling;

    void Awake()
    {
        buyPrice.text = buyValue.ToString() + ("$");
        sellPrice.text = sellValue.ToString() + ("$");
        itemImageShown.sprite = itemImage;
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
        isBuying = true;
        Debug.Log("buy");
    }
    public void SellItem()
    {
        isSelling = true;
        Debug.Log("sell");
    }

}
