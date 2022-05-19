using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GameManager : MonoBehaviour
{
    public static SCR_GameManager gameManager;

    [HideInInspector] public bool newGame;
    [HideInInspector] public bool playedLevelOne;
    [HideInInspector] public bool playedLevelTwo;
    [HideInInspector] public bool playedLevelThree;
    [HideInInspector] public bool playedLevelFour;

    void Awake()
    {
        if (gameManager != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            gameManager = this;
            DontDestroyOnLoad(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        newGame = true;
        playedLevelOne = false;
        playedLevelTwo = false;
        playedLevelThree = false;
        playedLevelFour = false;
    }
}
