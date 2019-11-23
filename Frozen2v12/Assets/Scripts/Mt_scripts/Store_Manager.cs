using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Adam Draheim
 * Simple Unity Microtransaction store manager
 * */
public class Store_Manager : MonoBehaviour
{

    public Text buyableName;
    public Text costText;
    public Image spriteImage;

    public enum purchase
    {
        character,
        level
    }

    //Struct for holding buyables
    [System.Serializable]
    public struct Buyable{
        public string name;
        public Sprite storeImage;
        public int cost;
        public int buyID;
        public purchase purchase_type;
        public bool purchased;
    };

    public Buyable[] store;

    private int currVal = 0;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        write();
        SaveData();
    }

    private void write()
    {
        buyableName.text = store[currVal].name;
        costText.text = (store[currVal].purchased ? "purchased" : "$" + store[currVal].cost);
        spriteImage.sprite = store[currVal].storeImage;

    }

    public void Buy()
    {
        Buyable current = store[currVal];
        if (!current.purchased)
        {
            if (Player_Purchase_Pref.purch_pref.SubtractMoney(current.cost))
            {
                current.purchased = true;
            }
        }
    }

    public void changeSelection(int change)
    {
        currVal += change;
        if(currVal < 0)
        {
            currVal += store.Length;
        }
        currVal %= store.Length;
    }

    public void SaveData()
    {
        foreach (Buyable buy in store)
        {
            PlayerPrefs.SetInt("store" + buy.buyID, (buy.purchased?1:0));
        }
    }

}
