using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Adam Draheim
 * Simple Unity Microtransaction store manager
 * */
public class Store_Manager : MonoBehaviour
{

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
    };

    public Buyable[] store;

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
        
    }
}
