using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameButton : MonoBehaviour
{
    private Button _button;
    [SerializeField]private IsPaused _isPaused;
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(PauseManager);
    }

    private void PauseManager()
    {
        if (_isPaused.GetPauseSatatus() == false)
        {
            Time.timeScale = 0f;
            _isPaused.SetPaused();
            Debug.Log("Paused");
        }
        else
        {
            Time.timeScale = 1f;
            _isPaused.SetResumed();
            Debug.Log("Resumed");
        }
    }
}
