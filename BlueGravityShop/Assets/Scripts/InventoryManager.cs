using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int playerMoney;
    public TMP_Text playerMoneyText;
    public List<GameObject> InventoryObjs = new List<GameObject>();
    public ShopInventoryManager myShopInventory;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMoneyText.text = playerMoney.ToString() + ("$");
    }
    
    public void AddItemToInventory(Item itm)
    {
        InventoryObjs.Add(itm.gameObject);
        itm.gameObject.transform.SetParent(gameObject.transform);
        //itm.GetComponent<Button>().onClick.RemoveAllListeners();
        //itm.GetComponent<Button>().onClick.AddListener(delegate { itm.EquipItem(); });
        itm.gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void RemoveItemFromInventory(Item itm)
    {
        InventoryObjs.Remove(itm.gameObject);
        itm.gameObject.transform.SetParent(myShopInventory.shopBuyScreen.gameObject.transform);
        //itm.GetComponent<Button>().onClick.RemoveAllListeners();
        //itm.GetComponent<Button>().onClick.AddListener(delegate { itm.BuyItem(); });
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
