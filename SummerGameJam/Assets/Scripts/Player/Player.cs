using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private GameObject _wastePanel;

    [Header("Начальное количество денег (если нет сохранений)")]
    [SerializeField] private float _startingMoney = 1000f;

    [Header("Звук столкновения")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _crashSound;

    private const string MoneyKey = "PlayerMoney";
    private float _money;

    public float Money => _money;

    private void Start()
    {
        // Загружаем из PlayerPrefs или создаём новое значение
        if (PlayerPrefs.HasKey(MoneyKey))
        {
            _money = PlayerPrefs.GetFloat(MoneyKey);
        }
        else
        {
            _money = _startingMoney;
            PlayerPrefs.SetFloat(MoneyKey, _money);
        }

        UpdateUI();
    }

    public void AddMoney(float amount)
    {
        _money += amount;
        SaveMoney();
        UpdateUI();
        Debug.Log($"+{amount}$ → {_money}$");
    }

    public void SubtractMoney(float amount)
    {
        _money -= amount;
        SaveMoney();
        UpdateUI();
        Debug.Log($"-{amount}$ → {_money}$");
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetFloat(MoneyKey, _money);
        PlayerPrefs.Save();
    }

    private void UpdateUI()
    {
        _moneyText.text = $"{_money:0000}$";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Obstacle obstacle))
        {
            _wastePanel.SetActive(true);
            Time.timeScale = 0.0f;

            if (_audioSource != null && _crashSound != null)
            {
                _audioSource.PlayOneShot(_crashSound);
            }

            Debug.Log("Столкновение с препятствием!");
        }
    }
}
