using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSortingLayer : MonoBehaviour
{

    private Rigidbody2D playerPosition;
    private bool playerInArea;
    [SerializeField] private GameObject parentGameObject;


    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if (playerInArea)
        {
            foreach (Transform child in parentGameObject.transform)
            {
                Rigidbody2D childRigidbody = child.GetComponent<Rigidbody2D>();
                SpriteRenderer childSprite = child.GetComponent<SpriteRenderer>();

                if(childRigidbody.position.y > playerPosition.position.y)
                {
                    childSprite.sortingOrder = -1;
                }
                else
                {
                    childSprite.sortingOrder = 1;
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInArea = true;
        Debug.Log("Player in area");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInArea = false;
    }


}
