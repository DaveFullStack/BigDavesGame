using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInventory : MonoBehaviour
{

    public GameObject inventoryUI;
    private PlayerController playerController;

    public GameObject coffeePanel;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if(playerController.inventoryOpen == true)
        {
            inventoryUI.SetActive(true);
        }
        else
        {
            inventoryUI.SetActive(false);
        }
    }

    public void OnCoffeeButtonClick()
    {
        if (!coffeePanel.activeInHierarchy)
        {
            coffeePanel.SetActive(true);
        }
    }


}
