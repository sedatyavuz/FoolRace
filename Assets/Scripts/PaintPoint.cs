using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPoint : MonoBehaviour
{
    [SerializeField] private Vector3 PaintPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.gameState = GameManager.GameState.Paint;
            other.transform.position = new Vector3(PaintPos.x, other.transform.position.y, PaintPos.z);
            other.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
    }
}
