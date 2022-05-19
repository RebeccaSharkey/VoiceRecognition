using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_Notes : MonoBehaviour
{
    [SerializeField] private GameObject notesButton;
    [SerializeField] private GameObject notesPanel;
    [SerializeField] private TextMeshProUGUI keyPhrasesUI;
    private Phrases phrases;

    void Start()
    {
        phrases = SCR_VoiceControl.voiceControl.GetPhrases();

        foreach (Phrase p in phrases.GetT_Phrases())
        {
            keyPhrasesUI.text += char.ToUpper(p.GetPhrase()[0]) + p.GetPhrase().Substring(1) + "\n";
        }
    }

    public void OnNotesPress()
    {
        SCR_CameraLook.cameraLook.TogglePausePlayer(true);

        notesButton.SetActive(false);
        notesPanel.SetActive(true);

    }

    public void OnContinuePress()
    {
        SCR_CameraLook.cameraLook.TogglePausePlayer(false);

        notesPanel.SetActive(false);
        notesButton.SetActive(true);
    }
}
