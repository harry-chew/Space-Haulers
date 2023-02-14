using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DisplayTooltip : MonoBehaviour
{
    [SerializeField] private GameObject toolTip;

    private bool isActive;

    private void OnEnable()
    {
        ModuleButton.OnModuleToolTip += Display;
        ModuleButton.OnModuleToolTipExit += Hide;
    }

    private void OnDisable()
    {
        ModuleButton.OnModuleToolTip -= Display;
        ModuleButton.OnModuleToolTipExit -= Hide;
    }

    private void Display(ModuleButton moduleButton)
    {
        toolTip.transform.position = Input.mousePosition;
        Debug.Log("what");
        isActive = true;
    }

    private void Hide()
    {
        isActive = false;
    }

    private void Update()
    {
        if (isActive)
        {
            toolTip.transform.position = Input.mousePosition;
            toolTip.SetActive(true);
        }
        else if (!isActive)
        {
            toolTip.SetActive(false);
        }
    }
}
