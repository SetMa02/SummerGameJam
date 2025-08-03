using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _vertcalSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private AudioSource _flightAudioSource;
    [SerializeField] private float _soundDelay = 2f;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private string Flying = "Flying";
    private string Win = "Win";
    private string Broken = "Broken";

    private float _lastThrustTime;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        bool isThrusting = Input.GetKey(KeyCode.W);

        if (isThrusting)
        {
            _rigidbody2D.AddForce(transform.up * _vertcalSpeed);
            _animator.SetTrigger(Flying);
            _lastThrustTime = Time.time;

            if (!_flightAudioSource.isPlaying)
                _flightAudioSource.Play();
        }

        // Если прошло больше 2 секунд после последнего thrust — выключаем звук
        if (_flightAudioSource.isPlaying && Time.time - _lastThrustTime > _soundDelay)
        {
            _flightAudioSource.Stop();
        }

        float rotateInput = 0f;
        if (Input.GetKey(KeyCode.A))
            rotateInput = 1f;
        else if (Input.GetKey(KeyCode.D))
            rotateInput = -1f;

        _rigidbody2D.MoveRotation(_rigidbody2D.rotation + rotateInput * _rotateSpeed * Time.fixedDeltaTime);
    }
}
