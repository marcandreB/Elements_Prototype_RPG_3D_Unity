using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GUI_Jeu : MonoBehaviour
{

    public Canvas GameCanvas;
    public Canvas OptionsCanvas; 
	public Canvas InventoryCanvas; 

    private void Awake()
    {
        OptionsCanvas.enabled = false; 
		InventoryCanvas.enabled = false; 
    }

	void Update(){
		if (Input.GetKeyDown ("I"))
			InventoryOn ();
	}

    public void OptionsOn()
    {
        OptionsCanvas.enabled = !(OptionsCanvas.enabled); 
    }

	public void InventoryOn()
	{
		OptionsCanvas.enabled = false; 
		InventoryCanvas.enabled = !(InventoryCanvas.enabled); 
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
