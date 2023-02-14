using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private int cashMoney;

    public static event Action<int> OnCashChanged;
    public static event Action<bool> OnCoreBuilt;
    
    public static SpaceShipController Instance { get; private set; }

    [SerializeField] private List<Cell> spaceShip = new List<Cell>();
    
    private void OnEnable()
    {
        Cell.OnModuleInstalled += HandleModuleInstallation;
        Cell.OnModuleUnInstalled += HandleModuleUnInstallation;
    }

    private void OnDisable()
    {
        Cell.OnModuleInstalled -= HandleModuleInstallation;
        Cell.OnModuleUnInstalled += HandleModuleUnInstallation;
    }
    
    private void HandleModuleInstallation(Cell obj)
    {
        ModuleButton module = obj.GetModule();
        SpendCash(module.GetCost());
        spaceShip.Add(obj);

        if (spaceShip.Count <= 1)
        {
            OnCoreBuilt?.Invoke(true);
        }
    }

    private void HandleModuleUnInstallation(Cell obj)
    {
        ModuleButton module = obj.GetModule();
        AddCash(module.GetCost());
        spaceShip?.Remove(obj);

        if (spaceShip.Count == 0)
        {
            OnCoreBuilt?.Invoke(false);
        }
    }

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

    public SpaceShipController GetInstance() {
        return Instance;
    }

    private void Start()
    {
        Initialise();
    }

    private void Initialise()
    {
        cashMoney = 10000;
        OnCashChanged?.Invoke(cashMoney);
    }

    public void AddCash(int amount)
    {
        cashMoney += amount;
        OnCashChanged?.Invoke(cashMoney);
    }

    public void SpendCash(int amount)
    {
        cashMoney -= amount;
        OnCashChanged?.Invoke(cashMoney);
    }

    public bool CanPurchaseModule(ModuleButton module)
    {
        return cashMoney >= module.GetCost();
    }
}
