using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public InventoryManager playerInventory;
    public ShopInventoryManager myShop;
    public List<Item> ShopInventory = new List<Item>();
    public BoxCollider2D shopArea;
    [HideInInspector] public bool isCharEntered;

    //public GameObject speachBubble;
    void Start()
    {
        SetShopInventoryToBuy();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        isCharEntered = true;
        Debug.Log("welcome");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isCharEntered = false;
        Debug.Log("bye");
    }

    public void AddItemToShop(Item itm)
    {
        myShop.ShopBuyInventory.Add(itm.gameObject);
        itm.gameObject.transform.SetParent(myShop.shopBuyScreen.gameObject.transform);
    }

    public void RemoveItemFromShop(Item itm)
    {
        myShop.ShopBuyInventory.Remove(itm.gameObject);
        itm.gameObject.transform.SetParent(playerInventory.gameObject.transform);

    }
    public void SetShopInventoryToBuy()
    {
        foreach (Item itm in ShopInventory)
        {
            GameObject newItemBuy = Instantiate(itm.gameObject);
            newItemBuy.gameObject.transform.SetParent(myShop.shopBuyScreen.gameObject.transform);
            newItemBuy.gameObject.SetActive(true);
            newItemBuy.GetComponent<Button>().onClick.AddListener(delegate { newItemBuy.gameObject.GetComponent<Item>().BuyItem(); });
            myShop.ShopBuyInventory.Add(newItemBuy);
        }
    }
}
