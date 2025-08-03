using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    [Header("Начальное количество денег")]
    [SerializeField] private float _money;

    public float Money => _money;

    private void Start()
    {
        UpdateUI();
    }

    public void AddMoney(float amount)
    {
        _money += amount;
        UpdateUI();
        Debug.Log($"+{amount}$ → {_money}$");
    }

    public void SubtractMoney(float amount)
    {
        _money -= amount;
        UpdateUI();
        Debug.Log($"-{amount}$ → {_money}$");
    }

    private void UpdateUI()
    {
        _moneyText.text = $"{_money:0000}$";
    }
}
