using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIGroupOperator : MonoBehaviour
{
    [FormerlySerializedAs("_targetGroup")] [SerializeField] private CanvasGroup _targetOpenGroup;

    [FormerlySerializedAs("_thisGroup")] [SerializeField]private CanvasGroup _targetCloseGroup;
    private Button _button;

    private void Start()
    {
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        OpenCG();
        CloseCG();
    }

    public void OpenCG()
    {
        OpenTargetCanvasGroup(_targetOpenGroup);
    }

    public void CloseCG()
    {
        CloseThisCanvasGroup();
    }

    private void OpenTargetCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }

    private void CloseThisCanvasGroup()
    {
        _targetCloseGroup.interactable = false;
        _targetCloseGroup.blocksRaycasts = false;
        _targetCloseGroup.alpha = 0;
    } 
}
