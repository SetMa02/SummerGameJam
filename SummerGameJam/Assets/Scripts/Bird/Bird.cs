using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private bool _flipOnTurn = true;

    private Transform _target;

    private void Start()
    {
        _target = _pointB;
    }

    private void Update()
    {
        if (_target == null) return; // ⛑ добавили защиту

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _target.position) < 0.1f)
        {
            _target = _target == _pointA ? _pointB : _pointA;

            if (_flipOnTurn)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
    }
}
