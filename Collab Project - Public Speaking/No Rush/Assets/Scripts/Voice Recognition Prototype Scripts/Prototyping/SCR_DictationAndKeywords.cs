using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;

public class SCR_DictationAndKeywords : MonoBehaviour
{
    private DictationRecognizer dictationRecognizer;
    [SerializeField] private TextMeshProUGUI dictationOutput;
    [SerializeField] private TextMeshProUGUI dictationHypoOutput;

    private KeywordRecognizer interjectionRecognizer;
    private Phrases interjections;
    [SerializeField] private string interjectionWords;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject stopButton;
    [SerializeField] private TextMeshProUGUI output;

    [SerializeField] private string[] keyWords;
    private Phrases keyPhrases;
    private string dictation;

    private void Awake()
    {
        keyPhrases = new Phrases(keyWords);
        interjections = new Phrases(interjectionWords);
    }

    public void OnStartPress()
    {
        //For speaking
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += (text, confidence) =>
        {
            dictationOutput.text += "\n" + text;
            dictation += text + " ";
        };
        dictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.Log("Dictation Error: " + error);
        };
        dictationRecognizer.DictationHypothesis += (text) =>
        {
            dictationHypoOutput.text += "\n" + text;
        };
        dictationRecognizer.Start();

        //For interjections
        interjectionRecognizer = new KeywordRecognizer(interjections.GetS_Phrases(), ConfidenceLevel.Low);
        interjectionRecognizer.OnPhraseRecognized += (args) =>
        {
            Debug.Log(args.text);
            interjections.GetPhrase(args.text).SetFound(true);
            output.text += char.ToUpper(interjections.GetPhrase(args.text).GetPhrase()[0]) + interjections.GetPhrase(args.text).GetPhrase().Substring(1) + "\n";

        };
        foreach (Phrase p in interjections.GetT_Phrases())
        {
            p.SetFound(false);
        }
        interjectionRecognizer.Start();

        //UI - Text
        output.text = "Key Words Mentioned:\n";

        //UI - Buttons
        stopButton.SetActive(true);
        startButton.SetActive(false);
    }

    public void OnStopPress()
    {
        //For speaking
        dictationRecognizer.Stop();
        dictationRecognizer.Dispose();

        //For Interjections
        interjectionRecognizer.Stop();
        interjectionRecognizer.Dispose();

        //Outputs said keyphrases at the end.
        dictationHypoOutput.text = "Key Words Mentioned:\n";
        

        //UI - Buttons
        startButton.SetActive(true);
        stopButton.SetActive(false);
    }
}
