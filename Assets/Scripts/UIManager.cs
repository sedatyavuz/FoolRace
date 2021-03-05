using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button StartButton, RetryButton;
    [SerializeField] private PaintPoint paintPoint;

    private bool StartValue = false;
    public bool StartValueGetSet { get { return StartValue; } set { StartValue = value; StartValueChange?.Invoke(StartValue); } }
    public delegate void OnPaintChangeVariable(bool newBool);
    public event OnPaintChangeVariable StartValueChange;

    private void Start()
    {
        paintPoint.PaintChange += ButtonActive;
    }

    public void StartGame() { StartValueGetSet = true; GameManager.Instance.gameState = GameManager.GameState.Play; }

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
