using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPoint : MonoBehaviour
{
    [SerializeField] private Vector3 PaintPos;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.gameState = GameManager.GameState.Paint;
            collision.gameObject.transform.position = PaintPos;
            collision.gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
    }
}
