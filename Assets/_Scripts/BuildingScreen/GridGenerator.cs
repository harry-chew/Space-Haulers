using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;

    [SerializeField] private int gridSize;

    private float cellSize;

    private GridLayoutGroup layoutGroup;
    
    private void Start()
    {
        Initialise();
        GenerateGrid(gridSize);
    }

    private void Initialise()
    {
        cellSize = GetComponent<RectTransform>().sizeDelta.x / gridSize;
        layoutGroup = GetComponent<GridLayoutGroup>();
        layoutGroup.cellSize = new Vector2(cellSize, cellSize);
    }

    private void GenerateGrid(int size)
    {
        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                CreateButton(i,j);
            }
        }
    }

    private void CreateButton(int x, int y)
    {
        var cell = Instantiate(cellPrefab, transform);
        cell.AddComponent<Cell>().SetPosition(x, y);
    }
}
