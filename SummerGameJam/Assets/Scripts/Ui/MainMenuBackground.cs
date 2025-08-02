using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBackground : MonoBehaviour
{
   [SerializeField] private RawImage _rawImage;
   [SerializeField] private Vector2 _scrollSpeed = new Vector2(0f, 0.1f); // По Y — сверху вниз

   private Rect _uvRect;

   private void Start()
   {
      _uvRect = _rawImage.uvRect;
   }

   private void Update()
   {
      _uvRect.position += _scrollSpeed * Time.deltaTime;
      _rawImage.uvRect = _uvRect;
   }
}
