using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Jeu : MonoBehaviour
{

    public Canvas GameCanvas;
    public Canvas OptionsCanvas; 

    private void Awake()
    {
        OptionsCanvas.enabled = false; 
    }

    public void OptionsOn()
    {
        OptionsCanvas.enabled = !(OptionsCanvas.enabled); 
    }

    public void ReturnOn()
    {
        OptionsCanvas.enabled = false;
    }

    public void quitterJeu()
    {
        Application.Quit();
    }

    public void LoadOn()
    {
        Application.LoadLevel(0);
    }
		
}
