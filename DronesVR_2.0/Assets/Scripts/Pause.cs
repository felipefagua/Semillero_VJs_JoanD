﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool menu = false;
    public GUISkin customSkin;
    public GameObject weapons;// weapon manager
    public GameObject gui;
	public Texture2D gamepad_buuton;
	public Texture2D gamepad_buuton2;



    void Update()
    {
        if (Input.GetButtonDown("Pause"))// if press "pause"
        {
            if (!menu)// if menu = false
            {
                menu = true; // menu = true
                menu_on();
				Time.timeScale = 0;// time stopped
                return;

            }
            else
            {
                menu = false;// menu = false
                Time.timeScale = 1;// time is normal
                menu_off();
                return;
            }


        }
		if ((menu == true)) {
			if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
				menu = false; // close menu
				Time.timeScale = 1;// normal time
				menu_off ();    
			}
			if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
				menu = false; // close menu
				Time.timeScale = 1;// normal time
				SceneManager.LoadScene (0, LoadSceneMode.Single);//reload scene
				menu_off ();    
			}
		}
    }

   void OnGUI()
	{
		GUI.skin = customSkin;

		if (menu) {// if menu = true
			GUI.DrawTexture(new Rect(Screen.width / 2 + 140, Screen.height / 2 - 140,50	,50), gamepad_buuton);   
			GUI.DrawTexture(new Rect(Screen.width / 2 + 140, Screen.height / 2 - 70,50	,50), gamepad_buuton2);   

			if (GUI.Button(new Rect(Screen.width / 2 - 140, Screen.height / 2 - 150, 280, 80), "Continue"))//if press "continue"
			{
				menu = false;//close menu
				Time.timeScale = 1;// normal time
				menu_off();

			}
			if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 -85, 280, 80), "Menu")) {// if press "menu"
				menu = false; // close menu
				Time.timeScale = 1;// normal time
				SceneManager.LoadScene (0, LoadSceneMode.Single);//reload scene
				menu_off ();                  
			}
		}
	}
        
    

    void menu_on()// if open menu
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>().enabled = false;    //
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>().enabled = false;//
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Crosshair>().enabled = false;//   deactivate all fpc scripts
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>().enabled = true;      //
        weapons.SetActive(false);// deactivate weapons
        gui.SetActive(false); // deactivate textures
		Cursor.visible = true; // cursor = true

    }

    void menu_off()// if menu close
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>().enabled = true;    //
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>().enabled = true;//
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Crosshair>().enabled = true;// activate all fpc scripts
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>().enabled = false;    //
        weapons.SetActive(true);// activate weapons
        gui.SetActive(true);// activate textures
		Cursor.visible = false;// cursor = true

    }
}
