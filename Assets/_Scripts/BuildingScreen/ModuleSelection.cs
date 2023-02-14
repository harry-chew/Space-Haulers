using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSelection : MonoBehaviour
{
    [SerializeField] private ModuleButton selectedModule;
    [SerializeField] private string moduleName;
    public static ModuleSelection Instance { get; private set; }

    private void OnEnable() => ModuleButton.OnModuleSelected += HandleModuleSelection;
    private void OnDisable() => ModuleButton.OnModuleSelected -= HandleModuleSelection;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public ModuleButton GetSelectedModule()
    {
        return selectedModule;
    }

    public void SetSelectedModule(ModuleButton module)
    {
        selectedModule = module;
        moduleName = module.name;
    }

    public void HandleModuleSelection(ModuleButton moduleButton)
    {
        SetSelectedModule(moduleButton);
    }
}
