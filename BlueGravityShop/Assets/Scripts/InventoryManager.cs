using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Item> InventoryItems = new List<Item>();
    public ShopInventoryManager myShopInventory;
    void Start()
    {
        SetInventory();
        SetShopInventoryToSell();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetInventory()
    {
        foreach (Item itm in InventoryItems)
        {
            GameObject newItem = Instantiate(itm.gameObject);
            newItem.gameObject.transform.SetParent(gameObject.transform);
            newItem.gameObject.SetActive(true);
            newItem.GetComponent<Button>().onClick.AddListener(delegate { itm.EquipItem(); });
        }
    }
    public void SetShopInventoryToSell()
    {
        foreach (Item itm in InventoryItems)
        {
            if (!myShopInventory.ShopSellInventory.Contains(itm))
            {
                myShopInventory.ShopSellInventory.Add(itm);
            }
        }
    }
    public void AddItemToInventory(Item itm)
    {
        InventoryItems.Add(itm);
        itm.gameObject.transform.SetParent(gameObject.transform);
        itm.GetComponent<Button>().onClick.AddListener(delegate { itm.EquipItem(); });
        itm.gameObject.transform.GetChild(1).gameObject.SetActive(false);

        SetShopInventoryToSell();
        myShopInventory.SetSellItems();
    }
    //public void RemoveItemFromInventory(Item itm)
    //{
    //    InventoryItems.Remove(itm);
    //    myShopInventory.AddBuyItems(itm);
        
    //    Destroy(itm.gameObject);
    //}
}
