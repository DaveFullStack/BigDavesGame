using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestCrops : MonoBehaviour
{
    public CropInfoScriptableObject cropInfo;
    public FarmManager farmManager;
    public FarmInventory farmInventory;

    private string[] origin = { "Ethiopia", "Brazil", "Colombia" };

    private string[] varietals = { "Pink Bourbon", "Gesha", "Pacamara"};

    private string[] tastingNotesOne = { "Grape", "Strawberry", "Custard Creams",
    "Red Wine", "Plum", "Apricot", "Peach", "Mud", "Tobacco", "Bad Breath", "Yuzu",
    "Sweet Orange", "Vanilla", "Dark Chocolate", "Cinnamon", "Depression"};

    private string[] tastingNotesTwo = {"Pear", "Honey", "Grapefruit", "Melon",
    "White Chocolate", "Bin Bags", "Vomit", "Coffee", "Baileys", "Cherry", "Blackberry",
    "Raspberry", "Cranberry", "Jasmine", "Chamomile"};


    //private void Start()
    //{
    //    //farmManager = FindObjectOfType<FarmManager>();
    //}



    public void HarvestCropsToInventory()
    {
        if (farmManager.cropsHarvestable)
        {
            AssignInformation();
            ResetSlotFullBool();
            AddInfoToCoffeeInventory();
        }
    }

    private void AssignInformation()
    {
        int randomInt = Random.Range(0, 3);
        int randomIntTwo = Random.Range(0, 3);
        int randomIntTastingNotes = Random.Range(0, (tastingNotesOne.Length));
        int randomIntTastingNotesTwo = Random.Range(0, (tastingNotesTwo.Length));
        int randomCoffeeRating = Random.Range(75, 95);

        cropInfo.origin = origin[randomInt];
        cropInfo.varietal = varietals[randomIntTwo];
        cropInfo.tastingNotes[0] = tastingNotesOne[randomIntTastingNotes];
        cropInfo.tastingNotes[1] = tastingNotesTwo[randomIntTastingNotesTwo];
        cropInfo.coffeeRating = randomCoffeeRating.ToString();
        cropInfo.yield = Random.Range(10, 26);
        Debug.Log("AssignInformation() assigned random information to cropInfo");
        
        
    }

    private void ResetSlotFullBool()
    {
        if (farmInventory.yieldCoffeeOne == 0)
        {
            farmInventory.slotFullCoffeeOne = false;
            Debug.Log("slotFullCoffeeOne Reset");
        }
        else if (farmInventory.yieldCoffeeTwo == 0)
        {
            farmInventory.slotFullCoffeeTwo = false;
            Debug.Log("slotFullCoffeeTwo Reset");
        }
        /*else if (farmInventory.yieldCoffeeThree == 0)
        {
            farmInventory.slotFullCoffeeThree = false;
            Debug.Log("slotFullCoffeeThree Reset");
        }*/

        else
        {
            Debug.Log("there is coffee in all 3 inventory slots so no bools reset");
            return;
        }
    }

    private void AddInfoToCoffeeInventory()
    {
        if (farmInventory.slotFullCoffeeOne == false)
        {
            string tastingNoteOne = cropInfo.tastingNotes[0];
            string tastingNoteTwo = cropInfo.tastingNotes[1];

            farmInventory.originCoffeeOne = cropInfo.origin;
            farmInventory.varietalCoffeeOne = cropInfo.varietal;
            farmInventory.tastingNotesCoffeeOne[0] = tastingNoteOne;
            farmInventory.tastingNotesCoffeeOne[1] = tastingNoteTwo;
            farmInventory.coffeeRatingCoffeeOne = cropInfo.coffeeRating;
            farmInventory.yieldCoffeeOne = cropInfo.yield;
            farmInventory.slotFullCoffeeOne = true;
            Debug.Log("Assigned coffee one info");
            return;
            

        }
        else if(farmInventory.slotFullCoffeeOne && !farmInventory.slotFullCoffeeTwo)
        {
            string tastingNoteOne = cropInfo.tastingNotes[0];
            string tastingNoteTwo = cropInfo.tastingNotes[1];

            farmInventory.originCoffeeTwo = cropInfo.origin;
            farmInventory.varietalCoffeeTwo = cropInfo.varietal;
            farmInventory.tastingNotesCoffeeTwo[0] = tastingNoteOne;
            farmInventory.tastingNotesCoffeeTwo[1] = tastingNoteTwo;
            farmInventory.coffeeRatingCoffeeTwo = cropInfo.coffeeRating;
            farmInventory.yieldCoffeeTwo = cropInfo.yield;
            farmInventory.slotFullCoffeeTwo = true;
            Debug.Log("Assigned coffee two info");
            return;
        }
        /*else if (farmInventory.slotFullCoffeeTwo && farmInventory.slotFullCoffeeOne && !farmInventory.slotFullCoffeeThree)
        {
            string tastingNoteOne = cropInfo.tastingNotes[0];
            string tastingNoteTwo = cropInfo.tastingNotes[1];

            farmInventory.originCoffeeThree = cropInfo.origin;
            farmInventory.varietalCoffeeThree = cropInfo.varietal;
            farmInventory.tastingNotesCoffeeThree[0] = tastingNoteOne;
            farmInventory.tastingNotesCoffeeThree[1] = tastingNoteTwo;
            farmInventory.coffeeRatingCoffeeThree = cropInfo.coffeeRating;
            farmInventory.yieldCoffeeThree = cropInfo.yield;
            farmInventory.slotFullCoffeeThree = true;
            Debug.Log("Assigned coffee three info");
            return;
        }*/
        else
        {
            Debug.Log("no space for coffee");
        }
    }
    public void OnApplicationQuit()
    {
        farmInventory.slotFullCoffeeOne = false;
        farmInventory.slotFullCoffeeTwo = false;
        //farmInventory.slotFullCoffeeThree = false;
        farmInventory.yieldCoffeeOne = 0;
        farmInventory.yieldCoffeeTwo = 0;
        //farmInventory.yieldCoffeeThree = 0;
    }
}
