using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasManager : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject ShopInventory;
    public ShopManager myShop;
    private bool isInventoryOpened;
    private bool isShopOpened;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Functions to open inventory screen, LeanTween library used for a smooth animation
        if(isInventoryOpened == false)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                LeanTween.moveX(Inventory, 0, 0.3f);
                isInventoryOpened = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                LeanTween.moveX(Inventory, -300, 0.3f);
                isInventoryOpened = false;
            }
        }
        if (myShop.isCharEntered == true && isShopOpened == false)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                ShopInventory.gameObject.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                ShopInventory.gameObject.SetActive(false);
            }
        }
        //if (Input.GetKeyDown(KeyCode.K) && myShop.isCharEntered == true && isShopOpened == false)
        //{
        //    LeanTween.moveY(ShopInventory, 0, 0.3f);
        //    isShopOpened = true;
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.K))
        //    {
        //        LeanTween.moveY(ShopInventory, 200, 0.3f);
        //        isShopOpened = false;
        //    }
        //}
    }
}
