using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int x;
    [SerializeField] private int y;

    [SerializeField] private bool isOccupied;
    [SerializeField] private ModuleButton module;

    public static event Action<Cell> OnModuleInstalled;
    public static event Action<Cell> OnModuleUnInstalled;
    

    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void SelectCell()
    {
        if (ModuleSelection.Instance.GetSelectedModule() == null || isOccupied) return;        
        ModuleButton selectedModule = ModuleSelection.Instance.GetSelectedModule();
        if (!SpaceShipController.Instance.CanPurchaseModule(selectedModule)) return;
        SetModule(selectedModule);
    }
    
    public ModuleButton GetModule() {
        return module;
    }

    public void SetModule(ModuleButton module)
    {
        this.module = module;
        isOccupied = true;
        img.color = module.GetComponent<Image>().color;
        OnModuleInstalled?.Invoke(this);
    }

    public void RemoveModule()
    {
        OnModuleUnInstalled?.Invoke(this);
        module = null;
        isOccupied = false;
        img.color = Color.white;
    }

    public void SetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public (int, int) GetPosition()
    {
        return (x, y);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        { 
            Debug.Log("Left click");
            SelectCell();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
            Debug.Log("Middle click");
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right click");
            RemoveModule();
        }
            
    }
}
