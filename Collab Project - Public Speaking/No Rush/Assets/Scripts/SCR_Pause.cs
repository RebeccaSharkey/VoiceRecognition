using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TextMeshProUGUI uiTimer;
    private IEnumerator timerRoutine;
    private int pauseAttempts = 0;
    [SerializeField] private int allowedPauses = 3;
    [SerializeField] private TextMeshProUGUI uiPause;
    [SerializeField] private GameObject hubButton;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject CheckScreen;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject noteButton;

    public void OnPausePress()
    {
        SCR_CameraLook.cameraLook.TogglePausePlayer(true);

        if (SCR_SceneManager.sceneManager.ReturnCurrentScene().name != "Hub Area")
        {
            noteButton.SetActive(false);
            timerRoutine = PauseTimer();
            StartCoroutine(timerRoutine);
            pauseAttempts++;
            uiPause.text = "Pause Attempts: " + pauseAttempts.ToString() + "/" + allowedPauses.ToString();
        }
        else
        {
            SCR_PlayerMovement.playerMovement.TogglePausePlayer(true);
            SCR_PlayerCasting.playerCasting.TogglePausePlayer(true);
            uiPause.gameObject.SetActive(false);
            uiTimer.gameObject.SetActive(false);
            continueButton.transform.position = hubButton.transform.position;
            hubButton.SetActive(false);
        }

        pauseButton.SetActive(false);
        pausePanel.SetActive(true);

    }

    public void OnContinuePress()
    {
        SCR_CameraLook.cameraLook.TogglePausePlayer(false);

        pausePanel.SetActive(false);
        if(SCR_SceneManager.sceneManager.ReturnCurrentScene().name == "Hub Area")
        {
            SCR_PlayerMovement.playerMovement.TogglePausePlayer(false);
            SCR_PlayerCasting.playerCasting.TogglePausePlayer(false);
            pauseButton.SetActive(true);
        }
        else if(pauseAttempts < allowedPauses)
        {
            noteButton.SetActive(true);
            pauseButton.SetActive(true);
            StopCoroutine(timerRoutine);
        }
    }

    public void OnRestartPress()
    {
        if (SCR_SceneManager.sceneManager.ReturnCurrentScene().name != "Hub Area")
            StopCoroutine(timerRoutine);
        SCR_SceneManager.sceneManager.LoadNewScene(SCR_SceneManager.sceneManager.ReturnCurrentScene().name);
    }

    public void OnHubRoomPress()
    {
        StopCoroutine(timerRoutine);
        SCR_SceneManager.sceneManager.LoadNewScene("Hub Area");
    }

    public void OnQuitPress()
    {
        if (SCR_SceneManager.sceneManager.ReturnCurrentScene().name != "Hub Area")
            StopCoroutine(timerRoutine);
        CheckScreen.SetActive(true);
    }

    public void OnYesPress()
    {
        Application.Quit();
    }
    public void OnNoPress()
    {
        CheckScreen.SetActive(false);
    }

    public void SeettingsPress()
    {
        settingsPanel.SetActive(true);
    }
    public void OnBackPress()
    {
        settingsPanel.SetActive(false);
    }

    IEnumerator PauseTimer()
    {
        int timer = 30;
        while(timer != 0f)
        {
            uiTimer.text = timer.ToString() + "s";
            yield return new WaitForSeconds(1f);
            timer--;
        }

        SCR_CameraLook.cameraLook.TogglePausePlayer(false);
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }

}
