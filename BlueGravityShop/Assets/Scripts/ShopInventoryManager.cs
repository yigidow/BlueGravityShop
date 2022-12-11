using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInventoryManager : MonoBehaviour
{
    public GameObject shopBuyScreen;
    public GameObject shopSellScreen;

    public List<Item> ShopBuyInventory = new List<Item>();
    public List<Item> ShopSellInventory = new List<Item>();

    public List<GameObject> ShopBuyInventoryGameObj = new List<GameObject>();
    public List<GameObject> ShopSellInventoryGameObj = new List<GameObject>();

    public InventoryManager playerInvenvory;
    public ShopManager Shop;

    void Awake()
    {
        SetBuyItems();
        SetSellItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSellItems()
    {    
        foreach (Item itm in ShopSellInventory)
        {
            GameObject newItemToSell = Instantiate(itm.gameObject);
            newItemToSell.gameObject.transform.SetParent(shopSellScreen.gameObject.transform);
            newItemToSell.gameObject.SetActive(true);
            newItemToSell.gameObject.GetComponent<Button>().onClick.AddListener(delegate { itm.SellItem(); });
            newItemToSell.GetComponent<Button>().onClick.AddListener(delegate { SwitchToBuyScreen(newItemToSell); });
            newItemToSell.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            ShopSellInventoryGameObj.Add(newItemToSell);
        }
    }
    public void SetBuyItems()
    {
        foreach (Item itm in ShopBuyInventory)
        {
            GameObject newItemToBuy = Instantiate(itm.gameObject);
            newItemToBuy.gameObject.transform.SetParent(shopBuyScreen.gameObject.transform);
            newItemToBuy.gameObject.SetActive(true);
            newItemToBuy.GetComponent<Button>().onClick.AddListener(delegate { itm.BuyItem(); });
            newItemToBuy.GetComponent<Button>().onClick.AddListener(delegate { SwitchToSellScreen(newItemToBuy); });
            newItemToBuy.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            ShopBuyInventoryGameObj.Add(newItemToBuy);
        }
    }
    public void SwitchToSellScreen(GameObject go)
    {
        go.transform.SetParent(shopSellScreen.gameObject.transform);
        go.GetComponent<Button>().onClick.AddListener(delegate { SwitchToBuyScreen(go); });
    }
    public void SwitchToBuyScreen(GameObject go)
    {
        go.transform.SetParent(shopBuyScreen.gameObject.transform);
        go.GetComponent<Button>().onClick.AddListener(delegate { SwitchToSellScreen(go); });
    }
    //public void AddSellItems(Item itm)
    //{
    //    foreach(Item itmSell in ShopBuyInventory)
    //    {
    //        if (itm == itmSell)
    //        {
    //            Debug.Log("buldum");
    //            itmSell.gameObject.transform.SetParent(shopSellScreen.gameObject.transform);
    //            itmSell.gameObject.GetComponent<Button>().onClick.AddListener(delegate { itmSell.SellItem(); });
    //            itmSell.gameObject.transform.GetChild(1).gameObject.SetActive(false);
    //            itmSell.gameObject.transform.GetChild(2).gameObject.SetActive(true);
    //        }
    //    }
    //}

    //public void AddBuyItems(Item itm)
    //{
    //    ShopBuyInventory.Add(itm);
    //    GameObject newItemToBuy = Instantiate(itm.gameObject);
    //    newItemToBuy.gameObject.transform.SetParent(shopBuyScreen.gameObject.transform);
    //    newItemToBuy.gameObject.SetActive(true);
    //    newItemToBuy.gameObject.GetComponent<Button>().onClick.AddListener(delegate { itm.BuyItem(); });
    //    newItemToBuy.gameObject.transform.GetChild(1).gameObject.SetActive(true);
    //}

}   
