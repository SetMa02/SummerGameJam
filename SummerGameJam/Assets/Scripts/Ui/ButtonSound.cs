using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip _soundClip;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySoundOnce);
    }

    private void PlaySoundOnce()
    {
        if (_soundClip != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(_soundClip);
        }
    }
}
