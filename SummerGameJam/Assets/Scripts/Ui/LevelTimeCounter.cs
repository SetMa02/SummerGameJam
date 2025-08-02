using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelTimeCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    
    private float _elapsedTime;
    private bool _isRunning = true;

    void Update()
    {
        if (!_isRunning) return;

        _elapsedTime += Time.deltaTime;

        int seconds = (int)_elapsedTime;
        int milliseconds = (int)((_elapsedTime - seconds) * 100); // 2 знака после запятой

        _timeText.text = $"{seconds:00}.{milliseconds:00}";
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    public void ResumeTimer()
    {
        _isRunning = true;
    }

    public float GetTime()
    {
        return _elapsedTime;
    }
}
