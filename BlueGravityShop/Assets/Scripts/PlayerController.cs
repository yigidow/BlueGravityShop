using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    public UICanvasManager myCanvasElements;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public Rigidbody2D myRigidbody2D;
    private float movSpeed = 5f;

    public List<Item> ownedItems = new List<Item>();
    public InventoryManager myInvenvory;

    public SpriteRenderer playerTshirt;
    public SpriteRenderer playerShorts;

    public ShopManager myShop;
    public int playerMoney;

    [HideInInspector] public Animator myAnim;
    void Start()
    {
        SetInventory();
    }

    // Update is called once per frame
    void Update()
    {
        myInvenvory.playerMoney = playerMoney;
        EquipItems();
        BuyItems();
        SellItems();
        if(myShop.isCharEntered && myCanvasElements.isShopOpened || myCanvasElements.isExitOpened)
        {
            movSpeed = 0;
        }
        else
        {
            movSpeed = 5f;
        }
        PlayerMovement();

    }
    void PlayerMovement()
    {
        // Basic movement of a 2D character by adding 2D velocity with a movement speed
        myRigidbody2D.velocity = (new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * movSpeed);

        //myAnim.SetFloat("movX", myRigidbody2D.velocity.x);
        myAnim.SetFloat("movY", myRigidbody2D.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            //myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3 (0.5f,1f,0f);
        topRightLimit = topRight + new Vector3(-0.5f, -1f, 0f);
    }
    public void SetInventory()
    {
        foreach (Item itm in ownedItems)
        {
            GameObject newItem = Instantiate(itm.gameObject);
            newItem.gameObject.transform.SetParent(myInvenvory.gameObject.transform);
            newItem.gameObject.SetActive(true);
            newItem.GetComponent<Button>().onClick.AddListener(delegate { newItem.gameObject.GetComponent<Item>().EquipItem(); });
            myInvenvory.InventoryObjs.Add(newItem);
        }
    }

    void EquipItems()
    {
        foreach (GameObject go in myInvenvory.InventoryObjs)
        {
            if (go.gameObject.GetComponent<Item>().isEquiped == true && go.gameObject.GetComponent<Item>().clotheType == ("top"))
            {
                playerTshirt.sprite = go.gameObject.GetComponent<Item>().itemImage;
                go.gameObject.GetComponent<Item>().isEquiped = false;
            }
            else if (go.gameObject.GetComponent<Item>().isEquiped == true && go.gameObject.GetComponent<Item>().clotheType == ("bottom"))
            {
                playerShorts.sprite = go.gameObject.GetComponent<Item>().itemImage;
                go.gameObject.GetComponent<Item>().isEquiped = false;
            }

        }
    }
    void BuyItems()
    {
        foreach(GameObject go in myShop.myShop.ShopBuyInventory)
        {
            if(go.gameObject.GetComponent<Item>().isBuying == true && playerMoney > go.gameObject.GetComponent<Item>().itemValue && !ownedItems.Contains(go.gameObject.GetComponent<Item>()))
            {
                ownedItems.Add(go.gameObject.GetComponent<Item>());
                myInvenvory.AddItemToInventory(go.gameObject.GetComponent<Item>());
                myShop.RemoveItemFromShop(go.gameObject.GetComponent<Item>());
                playerMoney -= go.gameObject.GetComponent<Item>().itemValue;
                go.gameObject.GetComponent<Item>().isBuying = false;
            }
        }
    }
    void SellItems()
    {
        foreach (GameObject go in myInvenvory.InventoryObjs)
        {
            if (go.gameObject.GetComponent<Item>().isSelling == true)
            {
                ownedItems.Remove(go.GetComponent<Item>());
                myInvenvory.RemoveItemFromInventory(go.gameObject.GetComponent<Item>());
                myShop.AddItemToShop(go.gameObject.GetComponent<Item>());
                playerMoney += go.gameObject.GetComponent<Item>().itemValue;
                go.gameObject.GetComponent<Item>().isSelling = false;
            }
        }
    }

}





