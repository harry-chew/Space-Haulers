using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCredits : MonoBehaviour
{
    private void OnEnable() => SpaceShipController.OnCashChanged += UpdateCreditsText;
    private void OnDisable() => SpaceShipController.OnCashChanged -= UpdateCreditsText;
    private void UpdateCreditsText(int obj) => GetComponent<TMPro.TextMeshProUGUI>().text = obj.ToString();
}

