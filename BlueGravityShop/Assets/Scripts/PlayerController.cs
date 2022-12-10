using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    private float movSpeed = 5f;

    public List<Item> ownedItems = new List<Item>();
    public InventoryManager myInvenvory;

    public SpriteRenderer playerTshirt;
    public SpriteRenderer playerShorts;

    public Animator myAnim;
    void Start()
    {
        foreach (Item itm in myInvenvory.ItemButtons)
        ownedItems.Add(itm);
    }

    // Update is called once per frame
    void Update()
    {
        // Basic movement of a 2D character by adding 2D velocity with a movement speed
        myRigidbody2D.velocity = (new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * movSpeed);

        myAnim.SetFloat("movX", myRigidbody2D.velocity.x);
        myAnim.SetFloat("movY", myRigidbody2D.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX" , Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }


        foreach (Item itm in ownedItems)
        {
            if (itm.isEquiped == true && itm.clotheType == ("top"))
            {
                playerTshirt.sprite = itm.itemImage;
            } else if (itm.isEquiped == true && itm.clotheType == ("bottom"))
            {
                playerShorts.sprite = itm.itemImage; 
            }

            }
        }
    }





