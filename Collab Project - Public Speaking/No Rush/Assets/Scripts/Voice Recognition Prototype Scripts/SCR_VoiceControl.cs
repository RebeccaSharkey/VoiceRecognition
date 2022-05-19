using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;

/*  ALL CODE USED IS UNIQUE AND SPECIFIC TO THIS GAME HOWEVER THE USE OF UNITY MANUEL WAS USED TO HELP GENERATE CODE.
 *  Link to code can be found here: https://docs.unity3d.com/ScriptReference/Windows.Speech.KeywordRecognizer.html
 *  Code is also referenced in Games Design Document.
*/

public class SCR_VoiceControl : MonoBehaviour
{
    //Makes static object to be used in other scripts
    public static SCR_VoiceControl voiceControl;

    //UI Buttons
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject stopButton;

    //UI Text
    [SerializeField] private TextMeshProUGUI aiText;

    //Interjections and phrases (and their actions) can be specified in inspector.
    [SerializeField] private Phrases interjections;
    [SerializeField] private Phrases phrases;

    //For recognition of words and interjections.
    private KeywordRecognizer recognizer;
    private string[] arrayOfInterjectionsAndPhrases;

    [SerializeField] private GameObject noMicPopUp;


    private void Awake()
    {
        voiceControl = this;

        //Creates new phrase classes for both interjections and the words wanted within the level.
        phrases.SetS_Phrases();
        interjections.SetS_Phrases();

        //Creates one big array to look for both interjections and keywords
        arrayOfInterjectionsAndPhrases = new string[phrases.GetS_Phrases().Length + interjections.GetS_Phrases().Length];
        phrases.GetS_Phrases().CopyTo(arrayOfInterjectionsAndPhrases, 0);
        interjections.GetS_Phrases().CopyTo(arrayOfInterjectionsAndPhrases, phrases.GetS_Phrases().Length);

        aiText.gameObject.SetActive(false);

    }

    public Phrases GetPhrases()
    {
        return phrases;
    }
    public Phrases GetInterjections()
    {
        return interjections;
    }

    public TextMeshProUGUI GetAIText()
    {
        return aiText;
    }

    public void OnStartPress()
    {
        StartRecognition();
    }

    public void OnStopPress()
    {
        StopRecognition();
    }

    private void StartRecognition()
    {
        if (Microphone.devices.Length != 0)
        {
            stopButton.SetActive(true);
            startButton.SetActive(false);

            //creates new Keyword Recogniser.
            recognizer = new KeywordRecognizer(arrayOfInterjectionsAndPhrases, ConfidenceLevel.Low);

            //Event that happens when a interjection is heard, just adds one to the amount of intejections said.
            recognizer.OnPhraseRecognized += (args) =>
            {
                //Checks if phrase is an interjection and does actions linked to interjection
                if (interjections.CheckIfPresent(args.text))
                {
                    interjections.GetPhrase(args.text).CheckWord();
                    interjections.GetPhrase(args.text).SetFound(true);
                }

                //Checks if the phrase is a keyword and does any actions linked to phrase
                else if (phrases.CheckIfPresent(args.text))
                {
                    phrases.GetPhrase(args.text).CheckWord();
                    phrases.GetPhrase(args.text).SetFound(true);
                }
            };


            //Sets all the phrases to found false.
            foreach (Phrase p in phrases.GetT_Phrases())
            {
                p.Reset();
            }
            foreach (Phrase p in interjections.GetT_Phrases())
            {
                p.Reset();
            }

            //starts the listening operation.
            recognizer.Start();
        }
        else
        {
            noMicPopUp.SetActive(true);
        }

        
    }
    private void StopRecognition()
    {
        startButton.SetActive(true);
        stopButton.SetActive(false);

        //Stops and deletes the recorders so not to use up too much memory.
        recognizer.Stop();
        recognizer.Dispose();
        SCR_Ending.ending.StartEnd();
    }
    
    public void OnContinuePress()
    {
        noMicPopUp.SetActive(false);
    }
}