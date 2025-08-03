using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearObstaclesBooster : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private Player _player;
    [SerializeField] private float _price;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(DisableObstaclesAndBuy);
    }

    private void DisableObstaclesAndBuy()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in obstacles)
        {
            obstacle.SetActive(false);
        }

        Debug.Log($"Отключено препятствий: {obstacles.Length}");

        _player.SubtractMoney(_price);
        _shopPanel.SetActive(false);

        Debug.Log($"Потрачено {_price}$, магазин скрыт.");
    }
}
