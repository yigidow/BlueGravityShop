using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<Item> ShopInventory = new List<Item>();
    public BoxCollider2D shopArea;
    public bool isCharEntered;

    //public GameObject speachBubble;
    void Start()
    {
        //foreach (Item itm in )
            //ownedItems.Add(itm);
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
}
