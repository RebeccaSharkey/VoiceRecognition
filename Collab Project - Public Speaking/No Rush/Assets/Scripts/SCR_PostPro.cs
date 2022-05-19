using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PostPro : MonoBehaviour
{
    public static SCR_PostPro postPro;

    private void Awake()
    {
        if(postPro != null)
        {            
            Destroy(gameObject);
        }
        else
        {
            postPro = this; 
            DontDestroyOnLoad(gameObject);
        }
    }



}
