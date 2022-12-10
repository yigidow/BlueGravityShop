using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int buyValue;
    public int sellValue;
    public string clotheType;

    public Sprite itemImage;

    public Image itemImageShown;

    public bool isEquiped ;

    void Awake()
    {
    itemImageShown.sprite = itemImage;
    }

// Update is called once per frame
    void Update()
        {
        
        }
    public void EquipItem() 
    {
        isEquiped = true;
    }
    

}
