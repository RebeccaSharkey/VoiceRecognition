using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Sign : MonoBehaviour
{
    private float distance;
    [SerializeField] private float usableDistance = 2f;
    [SerializeField] private GameObject signUI;

    private GameObject player;
    [SerializeField] private Camera playerCam;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distance = SCR_PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if(distance <= usableDistance && Input.GetKeyDown(KeyCode.E))
        {
            UseSign();
        }
    }

    void UseSign()
    {
        signUI.SetActive(true);
        player.GetComponent<SCR_PlayerMovement>().enabled = false;
        playerCam.GetComponent<SCR_CameraLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseSign()
    {
        signUI.SetActive(false);
        player.GetComponent<SCR_PlayerMovement>().enabled = true;
        playerCam.GetComponent<SCR_CameraLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
