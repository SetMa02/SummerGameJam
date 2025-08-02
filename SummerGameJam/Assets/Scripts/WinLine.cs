using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLine : MonoBehaviour
{
    [SerializeField] private LevelTimeCounter levelTimer;
    [SerializeField] private GameObject winMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelTimer.StopTimer();             
            winMenu.SetActive(true);            
            Time.timeScale = 0f;                
            Debug.Log("Победа!");
        }
    }
}
