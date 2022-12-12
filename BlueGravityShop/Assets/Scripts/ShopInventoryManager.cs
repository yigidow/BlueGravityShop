using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInventoryManager : MonoBehaviour
{
    public GameObject shopBuyScreen;

    public List<GameObject> ShopBuyInventory = new List<GameObject>();
    
    public InventoryManager playerInvenvory;
    public ShopManager Shop;

    void Awake()
    {
 ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeToBuy()
    {
        foreach (GameObject go in ShopBuyInventory)
        {
            go.GetComponent<Button>().onClick.RemoveAllListeners();
            go.GetComponent<Button>().onClick.AddListener(delegate { go.gameObject.GetComponent<Item>().BuyItem(); });
        }
    }
    public void ChangeToSell()
    {
        foreach (GameObject go in ShopBuyInventory)
        {
            go.GetComponent<Button>().onClick.RemoveAllListeners();
            go.GetComponent<Button>().onClick.AddListener(delegate { go.gameObject.GetComponent<Item>().SellItem(); });
        }
    }

}   
