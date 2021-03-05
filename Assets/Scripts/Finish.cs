using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private Text Score;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.FinishPos++;

            if (other.GetComponent<PlayerController>())
                Score.text = GameManager.Instance.FinishPos.ToString();
            else
                StartCoroutine(StopPlayer(other));
        }
    }

    IEnumerator StopPlayer(Collider other)
    {
        yield return new WaitForSeconds(5);
        other.GetComponent<NavMeshAgent>().stoppingDistance = 5;
    }
}
