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
            newItem.gameObject.GetComponent<Button>().onClick.AddListener(delegate { itm.EquipItem(); });
            newItem.gameObject.GetComponent<Button>().onClick.AddListener(delegate { itm.UnEquipOtherItems(); });
        }
    }
    public void SetShopInventoryToSell()
    {
        foreach (Item itm in InventoryItems)
        {
            myShopInventory.ShopSellInventory.Add(itm);
        }
    }
}
