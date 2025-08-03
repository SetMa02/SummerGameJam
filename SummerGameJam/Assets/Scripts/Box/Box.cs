using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private GameObject _wastePanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Obstacle obstacle))
        {
            _wastePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
