using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button StartButton, RetryButton;
    [SerializeField] private PaintPoint paintPoint;

    private void Start()
    {
        paintPoint.PaintChange += ButtonActive;
    }

    public void StartGame() => GameManager.Instance.gameState = GameManager.GameState.Play;

    public void ResGame() => SceneManager.LoadScene(0);

    private void ButtonActive(bool newBool)
    {
        if (newBool)
        {
            StartButton.gameObject.SetActive(false);
            RetryButton.gameObject.SetActive(true);
        }
    }
}
