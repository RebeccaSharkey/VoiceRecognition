using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Intro : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject notesButton;


    void Start()
    {
        if(level == 0)
        {
            if (SCR_GameManager.gameManager.newGame)
            {
                SCR_PlayerMovement.playerMovement.TogglePausePlayer(true);
                SCR_PlayerCasting.playerCasting.TogglePausePlayer(true);
                SCR_CameraLook.cameraLook.TogglePausePlayer(true);
                Cursor.lockState = CursorLockMode.None;
                pauseButton.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else
        {
            SCR_CameraLook.cameraLook.TogglePausePlayer(true);
            Cursor.lockState = CursorLockMode.None;
            pauseButton.SetActive(false);
            notesButton.SetActive(false);
        }
    }

    public void OnContinuePress()
    {
        if(level == 0)
        {
            SCR_PlayerMovement.playerMovement.TogglePausePlayer(false);
            SCR_PlayerCasting.playerCasting.TogglePausePlayer(false);
            SCR_CameraLook.cameraLook.TogglePausePlayer(false);
            Cursor.lockState = CursorLockMode.Locked;
            SCR_GameManager.gameManager.newGame = false;
            pauseButton.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            SCR_CameraLook.cameraLook.TogglePausePlayer(false);
            Cursor.lockState = CursorLockMode.Locked;
            pauseButton.SetActive(true);
            notesButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
