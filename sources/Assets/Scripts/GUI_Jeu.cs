﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GUI_Jeu : MonoBehaviour
{

	public Canvas GameCanvas;
	public Canvas QuestCanvas; 
    public Canvas OptionsCanvas; 
	public Canvas InventoryCanvas; 

    private void Awake()
    {
		OptionsCanvas.enabled = false; 
		QuestCanvas.enabled = false;
		InventoryCanvas.enabled = false;
    }

	void Update(){
		if (Input.GetKeyDown("i"))
			InventoryCanvas.enabled = !(InventoryCanvas.enabled); 
		if (Input.GetKeyDown("o"))
			OptionsCanvas.enabled = !(OptionsCanvas.enabled); 
		if (Input.GetKeyDown("q"))
			QuestCanvas.enabled = !(QuestCanvas.enabled); 
		if (Input.GetKeyDown("m"))
			Application.LoadLevel(0);
		if (Input.GetKeyDown("escape"))
			Application.Quit();
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

	public void QuestOn()
	{
		OptionsCanvas.enabled = false; 
		QuestCanvas.enabled = !(InventoryCanvas.enabled); 
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
