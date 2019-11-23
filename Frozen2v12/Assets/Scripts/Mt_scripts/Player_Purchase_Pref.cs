using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Purchase_Pref : MonoBehaviour
{

    public static Player_Purchase_Pref purch_pref;

    private int currentChar;
    private int money;

    // Start is called before the first frame update
    void Start()
    {

        if(purch_pref == null)
        {
            purch_pref = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetChararacter()
    {

    }

    public void SetCharacter(int character)
    {
        this.currentChar = character;
    }

    public int GetMoney()
    {
        return money;
    }

    public void AddMoney(int add)
    {
        money += add;
        PlayerPrefs.SetInt("money", money);
    }

    public bool SubtractMoney(int cost)
    {
        if(money >= cost)
        {
            money -= cost;
            PlayerPrefs.SetInt("money", money);
            return true;
        }
        return false;
    }

    public bool isPurchased(int ID)
    {
        if(PlayerPrefs.HasKey("store" + ID))
        {
            if (PlayerPrefs.GetInt("store" + ID) == 1)
            {
                return true;
            }
        }
        return false;
    }

}
