using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FarmInventory", menuName = "BigDavesGame/FarmInventory")]

public class FarmInventory : ScriptableObject
{
    /* create a scriptable object of the farm inventory to hold three different coffees
     * The coffee information will be supplied when the player presses the HarvestCrops button
     and the coffee inforamtion is sent to CropInfoScriptableObject
    
     */

    // General farm information
    public string farm = "Big Dave's Farm";

    // Coffee one information
    public string originCoffeeOne;
    public string varietalCoffeeOne;
    public string processCoffeeOne;
    public string[] tastingNotesCoffeeOne;
    public string coffeeRatingCoffeeOne;
    public int yieldCoffeeOne;
    public bool slotFullCoffeeOne;

    // Coffee two information
    public string originCoffeeTwo;
    public string varietalCoffeeTwo;
    public string processCoffeeTwo;
    public string[] tastingNotesCoffeeTwo;
    public string coffeeRatingCoffeeTwo;
    public int yieldCoffeeTwo;
    public bool slotFullCoffeeTwo;

    // Guest Coffee information
    public string originCoffeeGuest;
    public string varietalCoffeeGuest;
    public string processCoffeeGuest;
    public string[] tastingNotesCoffeeGuest;
    public string coffeeRatingCoffeeGuest;
    public int yieldCoffeeGuest;
    public bool slotFullCoffeeGuest;

    



}
