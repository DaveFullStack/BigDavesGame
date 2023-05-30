using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 moveDirection;
    private bool isWalking;
    private Animator animator;
    public bool isInteracting;

    public float moveSpeed = 3f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isWalking = false;
        isInteracting = false;
        
    }

    private void FixedUpdate()
    {
        Vector2 movement = (moveDirection * moveSpeed * Time.fixedDeltaTime);
        _rb.position += movement;
        
    }

    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>().normalized;

        if (moveDirection != Vector2.zero)
        {
            isWalking = true;
            animator.SetFloat("inputX", moveDirection.x);
            animator.SetFloat("inputY", moveDirection.y);
            animator.SetBool("isWalking", isWalking);
        }
        else
        {
            isWalking = false;
            animator.SetBool("isWalking", isWalking);
        }
    }

    private void OnInteract(InputValue value)
    {
        float interactionDuration = 0.5f;
        if (isInteracting) return;

        isInteracting = true;
        Debug.Log("Player is interacting");

        Invoke("EndInteraction", interactionDuration);
    }

    private void EndInteraction()
    {
        if(isInteracting == true)
        {
            isInteracting = false;
            
        }
        Debug.Log("Player is not interacting");
    }

}
