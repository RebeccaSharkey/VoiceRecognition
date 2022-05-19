using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;

public class SCR_VoiceRecognitionPrototype : MonoBehaviour
{
    private DictationRecognizer dictationRecognizer;

    [SerializeField] private TextMeshProUGUI output;
    [SerializeField] private TextMeshProUGUI textPopUp;
    [SerializeField] private TextMeshProUGUI[] finalCompare;

    private List<string> testRecognition;

    public void OnStartPress()
    {
        dictationRecognizer.Start();
    }

    public void OnStopPress()
    {
        dictationRecognizer.Stop();
        dictationRecognizer.Dispose();
    }
    
    void Start()
    {
        dictationRecognizer = new DictationRecognizer();
        testRecognition = new List<string>();

        dictationRecognizer.DictationResult += (text, confidence) =>
        {
            output.text += "\n" + text;
            testRecognition.Add(text);
        };

        dictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.Log("Dictation Error: " + error);
        };

        dictationRecognizer.DictationHypothesis += (text) =>
        {
            textPopUp.text += "\n" + text ;
        };
    }
}
