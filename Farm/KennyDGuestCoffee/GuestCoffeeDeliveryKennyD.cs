using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestCoffeeDeliveryKennyD : MonoBehaviour
{

    private GameObject ufo;
    private Rigidbody2D ufoRB;
    private Animator ufoAnimator;

    public float moveSpeed;

    public Vector2 startPosition; // set the start of ufo in inspector for more control
    public Vector2 targetPosition; // set the target position in inspector for more control

    // bool to control ufo movement. might setup movement animations to control with this variable.
    // need to change name of variable. something related to guest coffee button being pressed.
    public bool isMoving;

    public bool isLeaving;

    // creating bools to control animator bools.
    private bool emitLightBeam;
    private bool idleLightBeam;
    private bool exitLightBeam;


    public GameObject coffeeDeliveryToSpawn;



    // Start is called before the first frame update
    void Start()
    {
        ufo = gameObject;
        ufoRB = ufo.GetComponent<Rigidbody2D>();
        ufoAnimator = ufo.GetComponent<Animator>();
        ufoRB.position = startPosition;
    }

    private void FixedUpdate()
    {

        //when player presses button to order guest coffee

        //activate game object and move to start position using rigidbody 2D

        UfoEnter();
        //move game object from start position to target position using rigidbody 2D
        StartAnimationCycle();
        //when ufo reaches target position start light animation

        //when light is at full beam activate present game object and move present

        //when present is at target position light beam turning off animation proceeds.
        ReturnToStartPosition();
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
                ufoRB.position = targetPosition;
                emitLightBeam = true;
            }
        }
    }

    private IEnumerator CycleThroughUfoAnimations()
    {
        if (emitLightBeam)
        {
            ufoAnimator.SetBool("EmitLightBeam", true);

            yield return new WaitForSeconds(ufoAnimator.GetCurrentAnimatorStateInfo(0).length);

            emitLightBeam = false;
            idleLightBeam = true;
            ufoAnimator.SetBool("EmitLightBeam", false);
            ufoAnimator.SetBool("IdleLightBeam", true);
        }
        if (idleLightBeam)
        {
            coffeeDeliveryToSpawn.SetActive(true);
            yield return new WaitForSeconds(ufoAnimator.GetCurrentAnimatorStateInfo(0).length);

            idleLightBeam = false;
            exitLightBeam = true;
            ufoAnimator.SetBool("IdleLightBeam", false);
            ufoAnimator.SetBool("ExitLightBeam", true);
        }
        if (exitLightBeam)
        {
            yield return new WaitForSeconds(ufoAnimator.GetCurrentAnimatorStateInfo(0).length);

            exitLightBeam = false;
            ufoAnimator.SetBool("ExitLightBeam", false);
            isLeaving = true;
        }
    }

    private void StartAnimationCycle()
    {
        StartCoroutine(CycleThroughUfoAnimations());
    }

    private void ReturnToStartPosition()
    {
        if (isLeaving)
        {
            Vector2 moveDirection = (startPosition - ufoRB.position).normalized;
            Vector2 movement = moveDirection * (moveSpeed * Time.deltaTime);
            ufoRB.position += movement;

            if (Vector2.Distance(ufoRB.position, startPosition) <= 0.1f)
            {
                ufoRB.velocity = Vector2.zero;
                ufoRB.position = startPosition;
                isLeaving = false;
            }
        }
    }
}

