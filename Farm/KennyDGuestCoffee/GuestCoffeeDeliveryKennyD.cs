using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestCoffeeDeliveryKennyD : MonoBehaviour
{

    private GameObject ufo;
    private Rigidbody2D ufoRB;

    public float moveSpeed;

    public Vector2 startPosition; // set the start of ufo in inspector for more control
    public Vector2 targetPosition; // set the target position in inspector for more control

    public bool isMoving;


    // Start is called before the first frame update
    void Start()
    {
        ufo = gameObject;
        Debug.Log(ufo);
        ufoRB = ufo.GetComponent<Rigidbody2D>();
        ufoRB.position = startPosition;
    }

    private void FixedUpdate()
    {
        
        //when player presses button to order guest coffee

        //activate game object and move to start position using rigidbody 2D

        UfoEnter();
        //move game object from start position to target position using rigidbody 2D

        //when ufo reaches target position start light animation

        //when light is at full beam activate present game object and move present

        //when present is at target position light beam turning off animation proceeds.

        //when light animation has ended send ufo back to the start position and deactivate
    }

    private void UfoEnter()
    {
        if (isMoving)
        {
            Vector2 moveDirection = (targetPosition - ufoRB.position).normalized;
            Vector2 movement = moveDirection * (moveSpeed * Time.deltaTime);
            ufoRB.position += movement;
            
            if (Vector2.Distance(ufoRB.position, targetPosition) <= 0.1f)
            {
                isMoving = false;
                ufoRB.velocity = Vector2.zero;
            }
        }

    }
}
