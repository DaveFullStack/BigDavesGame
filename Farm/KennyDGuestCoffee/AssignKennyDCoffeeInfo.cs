using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignKennyDCoffeeInfo : MonoBehaviour
{

    public CropInfoScriptableObject kennyDCropInfo;
    public FarmInventory farmInventory;

    private string farmName = "The Four Acres";
    private string[] origin = { "Unknown", "Space", "Flat Earth", "Hollow Moon", "Mud Floods" };
    private string[] varietal = {"Space", "spaceeeeeee", "spac" };
    private string[] tastingNoteOne = {"Beef", "Rat", "Pickled Onion", "Saucy BBQ", "Space", "Unknown" };
    private string[] tastingNoteTwo = {"HazleNut", "Dimples", "Metal", "Feet", "Milky Way" };
    private string coffeeRating;
    private int yield;


    public void OnContinueButtonClick()
    {
        int randomOrigin = Random.Range(0, origin.Length);
        int randomVarietal = Random.Range(0, varietal.Length);
        int randomTastingNoteOne = Random.Range(0, tastingNoteOne.Length);
        int randomTastingNoteTwo = Random.Range(0, tastingNoteTwo.Length);
        coffeeRating = Random.Range(80, 100).ToString();
        yield = Random.Range(10, 15);

        kennyDCropInfo.farm = farmName;
        kennyDCropInfo.origin = origin[randomOrigin];
        kennyDCropInfo.varietal = varietal[randomVarietal];
        kennyDCropInfo.tastingNotes[0] = tastingNoteOne[randomTastingNoteOne];
        kennyDCropInfo.tastingNotes[1] = tastingNoteTwo[randomTastingNoteTwo];
        kennyDCropInfo.coffeeRating = coffeeRating;
        kennyDCropInfo.yield = yield;

        AddGuestToFarmInventory();
        
    }

    private void AddGuestToFarmInventory()
    {
        farmInventory.originCoffeeGuest = kennyDCropInfo.origin;
        farmInventory.varietalCoffeeGuest = kennyDCropInfo.varietal;
        farmInventory.tastingNotesCoffeeGuest[0] = kennyDCropInfo.tastingNotes[0];
        farmInventory.tastingNotesCoffeeGuest[1] = kennyDCropInfo.tastingNotes[1];
        farmInventory.coffeeRatingCoffeeGuest = kennyDCropInfo.coffeeRating;
        farmInventory.yieldCoffeeGuest = kennyDCropInfo.yield;
        farmInventory.slotFullCoffeeGuest = true;
    }
}
