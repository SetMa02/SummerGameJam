using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SlowTimeBooster : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _price;
    [SerializeField] private GameObject _shopPanel;
    private Button _button;
    
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SlowTime);
    }

    private void SlowTime()
    {
        Time.timeScale = 0.5f;
        
        _player.SubtractMoney(_price);
        _shopPanel.SetActive(false);

        Debug.Log($"Потрачено {_price}$, магазин скрыт.");
    }
}
