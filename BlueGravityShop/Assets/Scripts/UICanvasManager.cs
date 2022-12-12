using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UICanvasManager : MonoBehaviour
{
    public GameObject exitScreen;
    [HideInInspector] public bool isExitOpened;

    public GameObject Inventory;
    public bool isInventoryOpened;

    public ShopManager myShop;
    public GameObject shopMenu;
    public GameObject shopInventoryMenu;

    public bool isShopOpened;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isExitOpened == false)
            {
                exitScreen.SetActive(true);
                isExitOpened = true;
            }
            else
            {
                exitScreen.SetActive(false);
                isExitOpened = false;
            }
        }
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
        else if (myShop.isCharEntered == false)
        {
            closeShopMenu();

        }

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
        //Inventory.gameObject.transform.GetChild(1).GetComponent<InventoryManager>().ChangeToEquip();
    }

    public void openShopInventory()
    {
        shopInventoryMenu.gameObject.SetActive(true);
    }
    public void closeShopInventory()
    {
        shopInventoryMenu.gameObject.SetActive(false);
        //Inventory.gameObject.transform.GetChild(1).GetComponent<InventoryManager>().ChangeToEquip();
    }
    public void openShopMenu()
    {
        shopMenu.gameObject.SetActive(true);
        isShopOpened = true;
    }
    public void closeShopMenu()
    {
        shopMenu.gameObject.SetActive(false);
        myShop.isCharEntered = false;
        isShopOpened = false;
    }

    public void ExitShop()
    {
        closeShopInventory();
        closeInventoryMenu();
        closeShopMenu();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
