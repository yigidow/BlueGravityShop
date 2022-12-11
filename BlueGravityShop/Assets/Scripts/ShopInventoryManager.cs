using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryManager : MonoBehaviour
{
    public GameObject shopBuyScreen;
    public GameObject shopSellScreen;
    public List<GameObject> ShopBuyInventory = new List<GameObject> ();
    public List<GameObject> ShopSellInventory = new List<GameObject>();

    public InventoryManager playerInvenvory;
    public ShopManager Shop;

    void Start()
    {
        foreach (Item itm in playerInvenvory.ItemButtons) {
        ShopSellInventory.Add(itm.gameObject);
        itm.SetButtonFunctions();
        }
        foreach(GameObject itmShownToSell in ShopSellInventory)
        {
            GameObject newSellitem = Instantiate(itmShownToSell);
            newSellitem.gameObject.transform.SetParent(shopSellScreen.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
