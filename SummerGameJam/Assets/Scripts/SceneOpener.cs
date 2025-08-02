using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpener : MonoBehaviour
{
    [SerializeField]private string _targetScene;

    public void OpenTargetScene()
    {
        SceneManager.LoadScene(_targetScene);
    }
}
