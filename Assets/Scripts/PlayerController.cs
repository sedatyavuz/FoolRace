using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rb;

    private Animator animator;

    private bool isSwiping;

    private float movementSpeed;

    private Vector2 startPos;
    private Vector2 direction;
    private Vector2 swipeDelta;

    private Vector3 moveDirection = Vector3.forward;
    private Vector3 newDir;
    private Vector3 VeloMoveDirection;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.gameState != GameManager.GameState.Play)
        {
            animator.SetBool("run", false);
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            animator.SetBool("run", true);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    isSwiping = true;
                    direction = touch.position - startPos;
                    direction = Vector3.Normalize(direction);
                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    direction = Vector2.zero;
                    break;
            }

            swipeDelta = Vector2.zero;

            if (isSwiping)
            {
                if (Input.touches.Length > 0)
                {
                    swipeDelta = touch.position - startPos;
                }
            }

            if (swipeDelta.magnitude > 5)
            {
                moveDirection.x = direction.x;
                moveDirection.z = direction.y;
                moveDirection.y = 0;

                newDir = Vector3.RotateTowards(transform.forward, moveDirection, 0.3f, 0);

                transform.rotation = Quaternion.LookRotation(newDir);

                transform.Translate(moveDirection * Time.deltaTime * movementSpeed, Space.World);
            }

            VeloMoveDirection = moveDirection * Time.deltaTime * speed;
            rb.velocity = new Vector3(VeloMoveDirection.x, rb.velocity.y, VeloMoveDirection.z);
        }
        else
        {
            animator.SetBool("run", false);
        }

    }
}

