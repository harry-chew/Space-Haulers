using System;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class ModuleButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color32 color;
    [SerializeField] private int moduleCost;

    public static event Action<ModuleButton> OnModuleSelected;
    public static event Action<ModuleButton> OnModuleToolTip;
    public static event Action OnModuleToolTipExit;

    private void Start()
    {
        float red = Random.Range(0, 255);
        float green = Random.Range(0, 255);
        float blue = Random.Range(0, 255);

        Color32 clr = new Color32((byte)red, (byte)green, (byte)blue, 255);

        Button button = GetComponent<Button>();
        button.onClick.AddListener(SelectModule);

        SetCost();
        SetColor(clr);
    }


    public void SetCost()
    {
        moduleCost = Random.Range(100, 1000);
    }

    public int GetCost()
    {
        return moduleCost;
    }
    
    public void SetColor(Color32 color)
    {
        this.color = color;
        GetComponent<Image>().color = color;
    }
    
    public Color32 GetColor()
    {
        return this.color;
    }

    public void SelectModule()
    {
        OnModuleSelected?.Invoke(this);
        Debug.Log(this.moduleCost);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.dragging) return;
        OnModuleToolTip?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnModuleToolTipExit?.Invoke();
    }
}
