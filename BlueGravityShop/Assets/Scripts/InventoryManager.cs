using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [HideInInspector] public int playerMoney;
    public TMP_Text playerMoneyText;
    public List<GameObject> InventoryObjs = new List<GameObject>();
    public ShopInventoryManager myShopInventory;

    // Update is called once per frame
    void Update()
    {
        playerMoneyText.text = playerMoney.ToString() + ("$");
    }
    
    public void AddItemToInventory(Item itm)
    {
        InventoryObjs.Add(itm.gameObject);
        itm.gameObject.transform.SetParent(gameObject.transform);
    }
    public void RemoveItemFromInventory(Item itm)
    {
        InventoryObjs.Remove(itm.gameObject);
        itm.gameObject.transform.SetParent(myShopInventory.shopBuyScreen.gameObject.transform);

    }

    public void ChangeToSell()
    {
        foreach (GameObject go in InventoryObjs)
        {
            go.GetComponent<Button>().onClick.RemoveAllListeners();
            go.GetComponent<Button>().onClick.AddListener(delegate { go.gameObject.GetComponent<Item>().SellItem(); });
        }
    }
    public void ChangeToEquip()
    {
        foreach (GameObject go in InventoryObjs)
        {
            go.GetComponent<Button>().onClick.RemoveAllListeners();
            go.GetComponent<Button>().onClick.AddListener(delegate { go.gameObject.GetComponent<Item>().EquipItem(); });
        }
    }
}
