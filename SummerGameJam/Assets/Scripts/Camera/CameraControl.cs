using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10f);

    [SerializeField] private float _zoomSpeed = 5f;
    [SerializeField] private float _minZoom = 3f;
    [SerializeField] private float _maxZoom = 10f;

    private float _targetZoom;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _targetZoom = _camera.orthographicSize;
    }

    private void LateUpdate()
    {
        if (_target == null) return;

        // Камера плавно следует за дроном
        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, _offset.z); // Z остаётся фиксированным

        // Обработка зума через колёсико мыши
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.001f)
        {
            _targetZoom -= scroll * _zoomSpeed;
            _targetZoom = Mathf.Clamp(_targetZoom, _minZoom, _maxZoom);
        }

        // Плавное приближение/отдаление
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, _targetZoom, _smoothSpeed);
    }
}
