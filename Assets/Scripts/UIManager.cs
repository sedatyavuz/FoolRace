using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.gameState = GameManager.GameState.Play;
    }
}
