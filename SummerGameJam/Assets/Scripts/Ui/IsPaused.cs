using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPaused : MonoBehaviour
{
    private bool isPaused;

    private void Start()
    {
        isPaused = false;
    }

    public bool GetPauseSatatus()
    {
        return isPaused;
    }
    
    public void SetPaused()
    {
        isPaused = true;
        Debug.Log(isPaused);
    }

    public void SetResumed()
    {
        isPaused = false;
        Debug.Log(isPaused);
    }

}
