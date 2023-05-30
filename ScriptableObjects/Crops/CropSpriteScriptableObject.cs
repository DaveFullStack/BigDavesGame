using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "CropTiles", menuName = "BigDavesGame/CropTiles")]

public class CropSpriteScriptableObject : ScriptableObject
{
    public TileBase[] growthStageOne;
    public TileBase[] growthStageTwo;
    public TileBase[] growthStageThree;
    public TileBase[] growthStageFour;
    public TileBase[] growthStageFive;
    public TileBase[] growthStageSix;
    public TileBase[] growthStageSeven;

    public TileBase[] harvestable;
    public TileBase blankSpace;
}
