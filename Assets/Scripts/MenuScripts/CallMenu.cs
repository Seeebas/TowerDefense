using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMenu : MonoBehaviour
{
    public void callGame()
    {
        Application.LoadLevel("GameScene");
    }

    public void quitGame(){
        Application.Quit();
    }

    public void callMenuGame()
    {
        Application.LoadLevel("mainMenu");
    }
}
