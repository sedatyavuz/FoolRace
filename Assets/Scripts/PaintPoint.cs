using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPoint : MonoBehaviour
{
    [SerializeField] private Vector3 PaintPos;

    private bool paint;
    public bool PaintGetSet { get { return paint; } set { paint = value; PaintChange?.Invoke(paint); } }
    public delegate void OnPaintChangeVariable(bool newBool);
    public event OnPaintChangeVariable PaintChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.gameState = GameManager.GameState.CamChange;
            other.transform.position = new Vector3(PaintPos.x, other.transform.position.y, PaintPos.z);
            other.transform.rotation = Quaternion.LookRotation(Vector3.forward);
            PaintGetSet = true;
        }
    }
}
