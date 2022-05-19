using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_TestPanel : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject testOnePanel;
    [SerializeField] private GameObject testTwoPanel;

    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject pauseTestScene;
    [SerializeField] private GameObject dictationAndKeywords;

    public void OnTestOnePress()
    {
        testOnePanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void OnTestTwoPress()
    {
        testTwoPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void OnBackPress()
    {
        startPanel.SetActive(true);
        testOnePanel.SetActive(false);
        testTwoPanel.SetActive(false);
    }

    public void OnPauseTestPress()
    {
        mainCam.SetActive(false);
        startCanvas.SetActive(false);
        pauseTestScene.SetActive(true);
    }

    public void OnDictationAndKeywordsPress()
    {
        mainCam.SetActive(false);
        startCanvas.SetActive(false);
        dictationAndKeywords.SetActive(true);
    }

}
