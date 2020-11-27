using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe para dar off on do how to play ou main menu */
public class EnableCanvas : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasHowToPlay;
    // Use this for initialization
    void Start()
    {
        canvasHowToPlay.SetActive(false);
    }

    public void openHowToPlay()
    {
        canvasMenu.SetActive(false);
        canvasHowToPlay.SetActive(true);
    }
	 public void openMenu()
    {
        canvasHowToPlay.SetActive(false);
        canvasMenu.SetActive(true);
    }
}
