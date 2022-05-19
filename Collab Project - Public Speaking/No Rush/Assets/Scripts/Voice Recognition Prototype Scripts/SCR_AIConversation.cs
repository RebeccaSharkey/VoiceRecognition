using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_AIConversation : MonoBehaviour
{
    private TextMeshProUGUI aiOutput;
    
    void Start()
    {
        aiOutput = SCR_VoiceControl.voiceControl.GetAIText();
    }

    public void DoSomething(string placeHolder)
    {
        aiOutput.text = placeHolder;
        aiOutput.gameObject.SetActive(true);
    }
}
