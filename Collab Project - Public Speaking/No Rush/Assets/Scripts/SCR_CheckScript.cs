using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CheckScript : MonoBehaviour
{
    [HideInInspector] public string newScene;

    public void OnContinuePress()
    {
        SCR_SceneManager.sceneManager.LoadNewScene(newScene);
    }
    public void OnCancelPress()
    {
        SCR_PlayerCasting.playerCasting.TogglePausePlayer(false);
        SCR_PlayerMovement.playerMovement.TogglePausePlayer(false);
        SCR_CameraLook.cameraLook.TogglePausePlayer(false);
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }
}
