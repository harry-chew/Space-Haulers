using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySelectedModule : MonoBehaviour
{
    private void OnEnable() => ModuleButton.OnModuleSelected += HandleModuleSelection;
    private void OnDisable() => ModuleButton.OnModuleSelected -= HandleModuleSelection;

    private void HandleModuleSelection(ModuleButton obj)
    {
        GetComponent<Image>().color = obj.GetComponent<Image>().color;
    }


}
