using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_Ending : MonoBehaviour
{
    public static SCR_Ending ending;
    
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshProUGUI outputUI;
    private string outputString;
    private int amountOfInterjectionsUsed;
    private SCR_VoiceControl voiceControl;
    [SerializeField] private int level;
    [SerializeField] private GameObject CheckScreen;

    private void Awake()
    {
        ending = this;
    }

    public void StartEnd()
    {
        amountOfInterjectionsUsed = 0;
        outputString = "Keywords used: \n";


        switch (level)
        {
            case 1:
                SCR_GameManager.gameManager.playedLevelOne = true;
                break;
            case 2:
                SCR_GameManager.gameManager.playedLevelTwo = true;
                break;
            case 3:
                SCR_GameManager.gameManager.playedLevelThree = true;
                break;
            case 4:
                SCR_GameManager.gameManager.playedLevelFour = true;
                break;
        }
        
        voiceControl = SCR_VoiceControl.voiceControl;

        //Outputs on screen each 
        foreach (Phrase p in voiceControl.GetPhrases().GetT_Phrases())
        {
            if (p.GetFound())
            {
                outputString += char.ToUpper(p.GetPhrase()[0]) + p.GetPhrase().Substring(1) + "\n";
            }
        }

        //counts how many interjections were used.
        foreach (Phrase p in voiceControl.GetInterjections().GetT_Phrases())
        {
            amountOfInterjectionsUsed += p.GetTimesUsed();
        }

        outputUI.text = outputString + "\nAmount of Interjections Used: " + amountOfInterjectionsUsed;

        endPanel.SetActive(true);
    }

    public void OnHubRoomPress()
    {
        SCR_SceneManager.sceneManager.LoadNewScene("Hub Area");
    }
    public void OnRestartPress()
    {
        SCR_SceneManager.sceneManager.LoadNewScene(SCR_SceneManager.sceneManager.ReturnCurrentScene().name);
    }
    public void OnQuitPress()
    {
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

}
