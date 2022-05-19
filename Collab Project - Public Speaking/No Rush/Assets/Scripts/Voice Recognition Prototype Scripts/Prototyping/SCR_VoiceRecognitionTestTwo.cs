
using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;


public class SCR_VoiceRecognitionTestTwo : MonoBehaviour
{
    private KeywordRecognizer sentenceRecognizer;
    [SerializeField] private Phrases phrases;
    [SerializeField] private TextMeshProUGUI output;
    [SerializeField] private TextMeshProUGUI input;

    private void Start()
    {
        phrases = new Phrases(input.text);

        sentenceRecognizer = new KeywordRecognizer(phrases.GetS_Phrases(), ConfidenceLevel.Low);

        sentenceRecognizer.OnPhraseRecognized += (args) =>
        {
            Debug.Log(args.text);
            output.text += char.ToUpper(args.text[0]) + args.text.Substring(1) + ". ";
        };

    }

    public void OnStartPress()
    {
        sentenceRecognizer.Start();
    }

    public void OnStopPress()
    {
        sentenceRecognizer.Stop();
        sentenceRecognizer.Dispose();
    }
}

