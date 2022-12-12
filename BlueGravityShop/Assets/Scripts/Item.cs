using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public int itemValue;
    public string clotheType;

    public Sprite itemImage;

    public Image itemImageShown;
    public TMP_Text price;

    [HideInInspector] public bool isEquiped;
    [HideInInspector] public bool isBuying;
    [HideInInspector] public bool isSelling;

    void Awake()
    {
        price.text = itemValue.ToString() + ("$"); 
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
