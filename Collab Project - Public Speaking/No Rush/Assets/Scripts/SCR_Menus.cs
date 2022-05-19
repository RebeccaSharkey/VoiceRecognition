using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Menus : MonoBehaviour
{
    public void StartGame(string newScene)
    {
        SCR_SceneManager.sceneManager.LoadNewScene(newScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
