using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasManager : MonoBehaviour
{
    public GameObject Inventory;
    private bool isInventoryOpened;

    public ShopManager myShop;
    public GameObject shopMenu;
    public GameObject shopInventoryMenu;
 
    private bool isShopOpened;

    private bool shopBuyMenuOpened;
    private bool shopInventoryOpened;
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
                openInventoryMenu();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                closeInventoryMenu();
            }
        }
        if (myShop.isCharEntered == true && isShopOpened == false)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                openShopMenu();
            }
        }
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.K))
        //    {
        //        closeShopMenu();
        //    }
        //}
    }

    public void openInventoryMenu()
    {
        LeanTween.moveX(Inventory, 0, 0.3f);
        isInventoryOpened = true;
    }
    public void closeInventoryMenu()
    {
        LeanTween.moveX(Inventory, -300, 0.3f);
        isInventoryOpened = false;
    }

    public void openShopInventory()
    {
        shopInventoryMenu.gameObject.SetActive(true);
        shopInventoryOpened = true;
    }
    public void closeShopInventory()
    {
        shopInventoryMenu.gameObject.SetActive(false);
        shopInventoryOpened = false;
    }
    public void openShopMenu()
    {
        shopMenu.gameObject.SetActive(true);
        isShopOpened = true;
    }
    public void closeShopMenu()
    {
        shopMenu.gameObject.SetActive(false);
        isShopOpened = false;
    }

    public void ExitShop()
    {
        closeShopInventory();
        closeInventoryMenu();
        closeShopMenu();
    }

}
