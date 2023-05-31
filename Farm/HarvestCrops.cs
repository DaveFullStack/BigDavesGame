using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestCrops : MonoBehaviour
{
    public CropInfoScriptableObject cropInfo;
    public FarmManager farmManager;

    private string[] origin = { "Ethiopia", "Brazil", "Colombia" };

    private string[] varietals = { "Pink Bourbon", "Gesha", "Pacamara"};

    private string[] tastingNotesOne = { "Grape", "Strawberry", "Custard Creams",
    "Red Wine", "Plum", "Apricot", "Peach", "Mud", "Tobacco", "Bad Breath", "Yuzu",
    "Sweet Orange", "Vanilla", "Dark Chocolate", "Cinnamon", "Depression"};

    private string[] tastingNotesTwo = {"Pear", "Honey", "Grapefruit", "Melon",
    "White Chocolate", "Bin Bags", "Vomit", "Coffee", "Baileys", "Cherry", "Blackberry",
    "Raspberry", "Cranberry", "Jasmine", "Chamomile"};

    


    private void Start()
    {
        farmManager = FindObjectOfType<FarmManager>();
    }

    public void HarvestCropsToInventory()
    {
        if (farmManager.cropsHarvestable)
        {
            AssignInformation();
        }
    }

    private void AssignInformation()
    {
        int randomInt = Random.Range(0, 3);
        int randomIntTwo = Random.Range(0, 3);
        int randomIntTastingNotes = Random.Range(0, (tastingNotesOne.Length + 1));
        int randomIntTastingNotesTwo = Random.Range(0, (tastingNotesTwo.Length + 1));
        int randomCoffeeRating = Random.Range(75, 95);

        cropInfo.origin = origin[randomInt];
        cropInfo.varietal = varietals[randomIntTwo];
        cropInfo.tastingNotes[0] = tastingNotesOne[randomIntTastingNotes];
        cropInfo.tastingNotes[1] = tastingNotesTwo[randomIntTastingNotesTwo];
        cropInfo.coffeeRating = randomCoffeeRating.ToString();
        cropInfo.yield = Random.Range(10, 26).ToString() + " cups";
        
        
    }

}
