using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_Doors : MonoBehaviour
{
    [SerializeField] private string newScene;
    [SerializeField] private string outputToPlayer;
    [SerializeField] private TextMeshProUGUI playerText;
    private bool inDoorArea;
    [SerializeField] private GameObject checkPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inDoorArea = true;
            playerText.text = outputToPlayer;
            playerText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inDoorArea = false;
            playerText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inDoorArea)
        {
            if(newScene == "Level 1")
            {
                SCR_SceneManager.sceneManager.LoadNewScene(newScene);
            }
            else if (newScene == "Level 2 Open Day")
            {
                if(SCR_GameManager.gameManager.playedLevelOne)
                {
                    SCR_SceneManager.sceneManager.LoadNewScene(newScene);
                }
                else
                {
                    SCR_PlayerCasting.playerCasting.TogglePausePlayer(true);
                    SCR_PlayerMovement.playerMovement.TogglePausePlayer(true);
                    SCR_CameraLook.cameraLook.TogglePausePlayer(true);
                    Cursor.lockState = CursorLockMode.None;
                    checkPanel.SetActive(true);
                    checkPanel.GetComponent<SCR_CheckScript>().newScene = newScene;
                }
            }
            else if (newScene == "Level 3 Classroom")
            {
                if(SCR_GameManager.gameManager.playedLevelOne && SCR_GameManager.gameManager.playedLevelTwo)
                {
                    SCR_SceneManager.sceneManager.LoadNewScene(newScene);
                }
                else
                {
                    SCR_PlayerCasting.playerCasting.TogglePausePlayer(true);
                    SCR_PlayerMovement.playerMovement.TogglePausePlayer(true);
                    SCR_CameraLook.cameraLook.TogglePausePlayer(true);
                    Cursor.lockState = CursorLockMode.None;
                    checkPanel.SetActive(true);
                    checkPanel.GetComponent<SCR_CheckScript>().newScene = newScene;
                }
            }
            else
            {
                if (SCR_GameManager.gameManager.playedLevelOne && SCR_GameManager.gameManager.playedLevelTwo && SCR_GameManager.gameManager.playedLevelThree)
                {
                    SCR_SceneManager.sceneManager.LoadNewScene(newScene);
                }
                else
                {
                    SCR_PlayerCasting.playerCasting.TogglePausePlayer(true);
                    SCR_PlayerMovement.playerMovement.TogglePausePlayer(true);
                    SCR_CameraLook.cameraLook.TogglePausePlayer(true);
                    Cursor.lockState = CursorLockMode.None;
                    checkPanel.SetActive(true);
                    checkPanel.GetComponent<SCR_CheckScript>().newScene = newScene;
                }
            }                   
        }
    }
}
