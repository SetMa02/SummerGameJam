using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLine : MonoBehaviour
{
    [SerializeField] private LevelTimeCounter levelTimer;
    [SerializeField] private GameObject winMenu;

    [Header("Значения для звёзд")]
    [SerializeField] private float _oneStar = 20f;
    [SerializeField] private float _twoStar = 15f;
    [SerializeField] private float _threeStar = 10f;

    [SerializeField] private float _minReward;

    [Header("UI звёзд")]
    [SerializeField] private GameObject _star1;
    [SerializeField] private GameObject _star2;
    [SerializeField] private GameObject _star3;

    [Header("Менеджер денег")]
    [SerializeField] private Player _player;

    [Header("Звук победы")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _winSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Box box))
        {
            levelTimer.StopTimer();
            Time.timeScale = 0f;
            winMenu.SetActive(true);

            // Проигрываем победный звук
            if (_audioSource != null && _winSound != null)
                _audioSource.PlayOneShot(_winSound);

            float _finalTime = levelTimer.GetTime();
            int _stars = 1;

            if (_finalTime <= _threeStar)
                _stars = 3;
            else if (_finalTime <= _twoStar)
                _stars = 2;
            else if (_finalTime <= _oneStar)
                _stars = 1;
            else
                _stars = 0;

            ShowStars(_stars);
            RewardMoney(_stars);
            Debug.Log($"Победа за {_finalTime:F2} сек. Звёзды: {_stars}");
        }
    }

    private void ShowStars(int _stars)
    {
        _star1.SetActive(_stars >= 1);
        _star2.SetActive(_stars >= 2);
        _star3.SetActive(_stars >= 3);
    }

    private void RewardMoney(int _stars)
    {
        if (_stars <= 0) return;

        float _reward = _minReward * _stars;
        _player.AddMoney(_reward);
        Debug.Log($"Выдано денег: {_reward}$ за {_stars} звезды");
    }
}
