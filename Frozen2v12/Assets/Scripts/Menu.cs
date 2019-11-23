using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OpenTutorial(string scene)
    {
        if (Player_Purchase_Pref.purch_pref.isPurchased(1))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
