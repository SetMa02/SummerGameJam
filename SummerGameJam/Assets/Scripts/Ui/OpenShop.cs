using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private CanvasGroup _canvasGroup;

    private bool _isVisible = false;

    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(TogglePanel);
    }

    private void TogglePanel()
    {
        _isVisible = !_isVisible;

        _canvasGroup.alpha = _isVisible ? 1f : 0f;
        _canvasGroup.interactable = _isVisible;
        _canvasGroup.blocksRaycasts = _isVisible;
    }
}
