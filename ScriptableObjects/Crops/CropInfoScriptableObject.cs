using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CropInfo", menuName = "BigDavesGame/CropInfo")]
public class CropInfoScriptableObject : ScriptableObject
{
    public string farm = "Big Dave's Farm";
    public string origin;
    public string varietal;
    public string process;
    public string[] tastingNotes;
    public int coffeeRating;
    
}
