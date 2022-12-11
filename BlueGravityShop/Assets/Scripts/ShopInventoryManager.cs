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
            Debug.Log("setsell");
            GameObject newItemToSell = Instantiate(itm.gameObject);
            newItemToSell.gameObject.transform.SetParent(shopSellScreen.gameObject.transform);
            newItemToSell.gameObject.SetActive(true);
            newItemToSell.gameObject.GetComponent<Button>().onClick.AddListener(delegate { itm.SellItem(); });
            newItemToSell.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
    public void SetBuyItems()
    {
        foreach (Item itm in ShopBuyInventory)
        {
            Debug.Log("setbuy");
            GameObject newItemToBuy = Instantiate(itm.gameObject);
            newItemToBuy.gameObject.transform.SetParent(shopBuyScreen.gameObject.transform);
            newItemToBuy.gameObject.SetActive(true);
            newItemToBuy.gameObject.GetComponent<Button>().onClick.AddListener(delegate { itm.BuyItem(); });
            newItemToBuy.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
