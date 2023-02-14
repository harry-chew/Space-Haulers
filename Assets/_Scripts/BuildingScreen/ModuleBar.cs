using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleBar : MonoBehaviour
{
    [SerializeField] private GameObject modulePrefab;

    private HorizontalLayoutGroup layoutGroup;
    private float cellSizeX;
    private float cellSizeY;
    
    [SerializeField] private int moduleCells;

    private void Start() 
    {
        Initialise();
        GenerateBar(moduleCells);
    }

    private void Initialise()
    {
        cellSizeX = GetComponent<RectTransform>().sizeDelta.x / moduleCells;
        cellSizeY = GetComponent<RectTransform>().sizeDelta.y;
        layoutGroup = GetComponent<HorizontalLayoutGroup>();
    }

    private void GenerateBar(int size)
    {
        for (int i = 0; i < size; i++)
        {
            CreateButton(i);
        }
    }

    private void CreateButton(int n)
    {
        var module = Instantiate(modulePrefab, transform);
        module.GetComponent<RectTransform>().sizeDelta = new Vector2(cellSizeX, cellSizeY);
        module.AddComponent<ModuleButton>();
        module.name = "Module: " + n;

    }
}
