using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableModules : MonoBehaviour
{
    [SerializeField] private List<ShipModule> availableModules = new List<ShipModule>();
    public static AvailableModules Instance { get; private set; }
    private void Awake()
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

    private void Start()
    {
        AddModule(new CoreModule());
    }
    public List<ShipModule> GetAvailableModules()
    {
        return availableModules;
    }

    public void AddModule(ShipModule module)
    {
        availableModules.Add(module);
    }
}
