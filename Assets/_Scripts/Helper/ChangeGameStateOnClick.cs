using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameStateOnClick : MonoBehaviour
{
    [SerializeField]
    private GameController.GameState gameState;

    public void ChangeGameState()
    {
        GameController.Instance.SetGameState(gameState);
    }
}
