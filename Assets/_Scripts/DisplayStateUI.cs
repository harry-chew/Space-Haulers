using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStateUI : MonoBehaviour
{
    private void OnEnable() => GameController.OnStateChange += HandleStateChange;
    private void OnDisable() => GameController.OnStateChange -= HandleStateChange;

    private void HandleStateChange(GameController.GameState state)
    {
        foreach (Transform child in transform)
        {
            if(child.CompareTag(state.ToString()))
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
