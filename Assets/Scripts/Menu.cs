using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Menu : MonoBehaviour {

    public Canvas MainCanvas;
    
    private void Awake()
    {

    }


    public void quitterJeu()
    {
        Application.Quit();
    }

    public void LoadOn()
    {
        Application.LoadLevel(1);
    }
}
