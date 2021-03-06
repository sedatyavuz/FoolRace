﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform PaintCamPos;

    [SerializeField] private float smoothSpeed;
    [SerializeField] private float ChangeCamSpeed;


    private Vector3 offset;



    private void Start()
    {
        offset = transform.position - target.position;
    }


    private void LateUpdate()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Play)
        {
            FollowPlayer();
            return;
        }
        if (GameManager.Instance.gameState == GameManager.GameState.CamChange)
        {
            ChangeCam();

            if (Mathf.Abs(transform.position.z - target.position.z) <= 0.01f)
                GameManager.Instance.gameState = GameManager.GameState.Paint;
        }
    }

    private void FollowPlayer()
    {
        Vector3 nextPos = target.position + offset;
        Vector3 smootPos = Vector3.Lerp(transform.position, nextPos, smoothSpeed);
        transform.position = smootPos;
    }

    private void ChangeCam()
    {
        transform.position = Vector3.Lerp(transform.position, PaintCamPos.position, Time.deltaTime * ChangeCamSpeed);
        transform.eulerAngles = new Vector3(
            Mathf.LerpAngle(transform.rotation.x, PaintCamPos.rotation.x, Time.deltaTime * ChangeCamSpeed), transform.rotation.y, transform.rotation.z);
    }
}
