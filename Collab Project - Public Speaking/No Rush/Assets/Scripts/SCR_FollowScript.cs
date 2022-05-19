using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_FollowScript : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + player.transform.forward);
    }
}
