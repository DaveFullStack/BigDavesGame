using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class InvAssignCoffeeInfo : MonoBehaviour
{
    public FarmInventory farmInventory;
    public TextMeshProUGUI coffeeOneText;
    public TextMeshProUGUI coffeeTwoText;

    private PlayerController playerController;

    private bool inventoryOpen; // need to assign variable from playercontroller im yet to set up. OnInventory()
    private bool coffeeInfoAssigned; // reset to false when coffee yield is at 0

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        //inventoryOpen = true; // just for testing
        
    }

    public void Update()
    {
        inventoryOpen = playerController.inventoryOpen;
        if (inventoryOpen)
        {
            DisplayCoffeeInformation();
        }
    }

    private void DisplayCoffeeInformation()
    {
        coffeeOneText.text = $"Origin: {farmInventory.originCoffeeOne} \n" +
                $"Variety: {farmInventory.varietalCoffeeOne}\n" +
                $"Tasting Notes: {farmInventory.tastingNotesCoffeeOne[0]}, {farmInventory.tastingNotesCoffeeOne[1]} \n" +
                $"Rating: {farmInventory.coffeeRatingCoffeeOne} / 100" +
                $"Yield: {farmInventory.yieldCoffeeOne} Cups";

        coffeeTwoText.text = $"Origin: {farmInventory.originCoffeeTwo} \n" +
                $"Variety: {farmInventory.varietalCoffeeTwo}\n" +
                $"Tasting Notes: {farmInventory.tastingNotesCoffeeTwo[0]}, {farmInventory.tastingNotesCoffeeTwo[1]} \n" +
                $"Rating: {farmInventory.coffeeRatingCoffeeTwo} / 100" +
                $"Yield: {farmInventory.yieldCoffeeTwo} Cups";
    }
}
