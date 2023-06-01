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

    private bool inventoryOpen; // need to assign variable from playercontroller im yet to set up. OnInventory()
    private bool coffeeInfoAssigned; // reset to false when coffee yield is at 0

    private void Start()
    {
        inventoryOpen = true; // just for testing
        
    }

    public void Update()
    {
        if (inventoryOpen) // need to use coffeeInfoAssignedBool
        {
            coffeeOneText.text = $"Origin: {farmInventory.originCoffeeOne} \n" +
                $"Variety: {farmInventory.varietalCoffeeOne}\n" +
                $"Tasting Notes: {farmInventory.tastingNotesCoffeeOne[0]}, {farmInventory.tastingNotesCoffeeOne[1]} \n" +
                $"Rating: {farmInventory.coffeeRatingCoffeeOne} / 100";
        }
    }
}
