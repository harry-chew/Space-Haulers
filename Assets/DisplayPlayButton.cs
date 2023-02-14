using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayButton : MonoBehaviour
{
    [SerializeField] private GameObject playButton;

    private void OnEnable() => SpaceShipController.OnCoreBuilt += HandleCoreBuilt;
    private void OnDisable() => SpaceShipController.OnCoreBuilt -= HandleCoreBuilt;
    
    private void Start()
    {
        playButton.SetActive(false);
    }

    private void HandleCoreBuilt(bool obj)
    {
        playButton.SetActive(obj);
    }
}
