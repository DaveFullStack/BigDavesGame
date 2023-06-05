using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuestCoffeeToInventory : MonoBehaviour
{
    private GameObject coffeeDeliveryBox;

    private bool playerInArea;
    public GameObject canvasGuestCoffeeText;
    public TextMeshProUGUI textToDisplay;

    private PlayerController playerController;
    

    public string[] textOptions;

    

    // Start is called before the first frame update
    void Start()
    {
        coffeeDeliveryBox = gameObject;
        playerController = FindObjectOfType<PlayerController>();
        Debug.Log(playerController);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerInArea);
        
        if (playerInArea && !canvasGuestCoffeeText.activeInHierarchy)
        {
            if (playerController.isInteracting)
            {
                Debug.Log("Calling displaytext");
                DisplayText();
                playerController.isInteracting = false;
                return;
            }
            
        }
        
    }

    private void DisplayText()
    {
        canvasGuestCoffeeText.SetActive(true);
        string chosenText = textOptions[Random.Range(0, textOptions.Length)];
        textToDisplay.text = chosenText;
        //playerController.isInteracting = false;
        

    }

    public void ContinueButton()
    {
        canvasGuestCoffeeText.SetActive(false);
        coffeeDeliveryBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInArea = true;
            Debug.Log("player in area");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInArea = false;
        Debug.Log("Player not in area");
    }

    
}
