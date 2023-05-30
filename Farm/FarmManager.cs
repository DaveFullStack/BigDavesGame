using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;


public class FarmManager : MonoBehaviour
{
    private PlayerController playerController;
    private GameObject player;
    private bool playerInArea;

    public GameObject uiCanvas;


    public Tilemap[] growingCrops;
    public CropSpriteScriptableObject cropTiles;

    private bool cropsPlanted;
    private float cropGrowTimer = 0;
    private int growthStage = 0;
    public bool cropsHarvestable;

    private Dictionary<int, TileBase[]> growthStageTiles = new Dictionary<int, TileBase[]>();


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = FindObjectOfType<PlayerController>();
        playerInArea = false;
        cropsPlanted = false;
        cropsHarvestable = false;

        growthStageTiles.Add(1, cropTiles.growthStageOne);
        growthStageTiles.Add(2, cropTiles.growthStageTwo);
        growthStageTiles.Add(3, cropTiles.growthStageThree);
        growthStageTiles.Add(4, cropTiles.growthStageFour);
        growthStageTiles.Add(5, cropTiles.growthStageFive);
        growthStageTiles.Add(6, cropTiles.growthStageSix);
        growthStageTiles.Add(7, cropTiles.growthStageSeven);
        growthStageTiles.Add(8, cropTiles.harvestable);


    }

    // Update is called once per frame
    void Update()
    {
        OpenFarmManagerUI();

        if (cropsPlanted)
        {
            GrowCrops();
        }
        
    }

    private void OpenFarmManagerUI()
    {
        if (playerInArea && !uiCanvas.activeInHierarchy)
        {
            if (playerController.isInteracting)
            {
                uiCanvas.SetActive(true);
                playerController.isInteracting = false;
            }
        }
        else
        {
            if (!playerInArea || playerController.isInteracting)
            {
                uiCanvas.SetActive(false);
                playerController.isInteracting = false;

            }
        }
    }

    public void PlantCropsButton()
    {

        if (!cropsPlanted && !cropsHarvestable)
        {
            cropsPlanted = true;
            Debug.Log("Planting crops");
        }
        else
        {
            Debug.Log("Crops are already planted");
        }
    }

    public void HarvestCropsButton()
    {
        if (cropsHarvestable)
        {
            BoundsInt bounds = growingCrops[0].cellBounds;

            foreach (var tile in bounds.allPositionsWithin)
            {
                if (growingCrops[0].HasTile(tile))
                {
                    growingCrops[0].SetTile(tile, cropTiles.growthStageOne[0]);
                }
            }
            
            cropsHarvestable = false;
            growingCrops[0].gameObject.SetActive(false);

        }

    }

    private void GrowCrops()
    {
        if (!growingCrops[0].gameObject.activeInHierarchy)
        {
            growingCrops[0].gameObject.SetActive(true);
        }
        
        cropGrowTimer -= Time.deltaTime;

        if (cropGrowTimer <= 0)
        {
            ChangeTile();
            cropGrowTimer = 3f; 
        }
    }

    private void ChangeTile()
    {
        Debug.Log("Changing tile");
        //growthStage += 1;

        BoundsInt bounds = growingCrops[0].cellBounds;

        if (growthStageTiles.ContainsKey(growthStage))
        {
            TileBase[] tileArray = growthStageTiles[growthStage];

            foreach (var tile in bounds.allPositionsWithin)
            {
                if (growingCrops[0].HasTile(tile))
                {
                    int randomInt = Random.Range(0, 3);
                    growingCrops[0].SetTile(tile, tileArray[randomInt]);
                }
            }

            if (growthStage == 8)
            {
                foreach (var tile in bounds.allPositionsWithin)
                {
                    if (growingCrops[0].HasTile(tile))
                    {
                        int randomInt = Random.Range(0, 3);
                        growingCrops[0].SetTile(tile, tileArray[randomInt]);
                    }
                }
                growthStage = 0;
                cropsHarvestable = true;
                cropsPlanted = false;
                //Debug.Log(cropGrowTimer);
            }
        }
        growthStage += 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInArea = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInArea = false;
    }


    //private void ChangeTile()
    //{
    //    Debug.Log("Changing tile");
    //    growthStage += 1;

    //    BoundsInt bounds = growingCrops[0].cellBounds;

    //    foreach (var tile in bounds.allPositionsWithin)
    //    {
    //        if (growthStage == 1)
    //        {
    //            if (growingCrops[0].HasTile(tile))
    //            {
    //                int randomInt = Random.Range(0, 3);
    //                growingCrops[0].SetTile(tile, cropTiles.growthStageTwo[randomInt]);
    //            }
    //        }
    //        else if (growthStage == 2)
    //        {
    //            if (growingCrops[0].HasTile(tile))
    //            {
    //                int randomInt = Random.Range(0, 3);
    //                growingCrops[0].SetTile(tile, cropTiles.growthStageThree[randomInt]);
    //            }
    //        }
    //        else if (growthStage == 4)
    //        {
    //            if (growingCrops[0].HasTile(tile))
    //            {
    //                int randomInt = Random.Range(0, 3);
    //                growingCrops[0].SetTile(tile, cropTiles.growthStageFour[randomInt]);
    //            }
    //        }
    //        else if (growthStage == 5)
    //        {
    //            if (growingCrops[0].HasTile(tile))
    //            {
    //                int randomInt = Random.Range(0, 3);
    //                growingCrops[0].SetTile(tile, cropTiles.growthStageFive[randomInt]);
    //            }
    //        }
    //        else if (growthStage == 6)
    //        {
    //            if (growingCrops[0].HasTile(tile))
    //            {
    //                int randomInt = Random.Range(0, 3);
    //                growingCrops[0].SetTile(tile, cropTiles.growthStageSix[randomInt]);
    //            }
    //        }
    //        else if (growthStage == 7)
    //        {
    //            if (growingCrops[0].HasTile(tile))
    //            {
    //                int randomInt = Random.Range(0, 3);
    //                growingCrops[0].SetTile(tile, cropTiles.growthStageSeven[randomInt]);
    //            }
    //        }
    //        else if (growthStage == 8)
    //        {
    //            if (growingCrops[0].HasTile(tile))
    //            {
    //                int randomInt = Random.Range(0, 3);
    //                growingCrops[0].SetTile(tile, cropTiles.harvestable[randomInt]);
    //                growthStage = 0;
    //                cropsHarvestable = true;
    //                cropsPlanted = false;
    //                //Debug.Log(cropGrowTimer);
    //            }
    //        }
    //    }
    //}



    //private void GrowCrops()
    //{
    //    growingCrops[0].gameObject.SetActive(true);

    //    cropGrowTimer += Time.deltaTime;
    //    //Debug.Log(cropGrowTimer);

    //    if (cropGrowTimer >= 4 && cropGrowTimer <= 6)
    //    {
    //        Debug.Log("Growth Stage 2");
    //        BoundsInt bounds = growingCrops[0].cellBounds;

    //        foreach (var position in bounds.allPositionsWithin)
    //        {
    //            if (growingCrops[0].HasTile(position))
    //            {
    //                growingCrops[0].SetTile(position, cropTiles.growthStageTwo[0]);
    //            }
    //        }
    //    }
    //    else if (cropGrowTimer >= 9 && cropGrowTimer <= 11)
    //    {
    //        Debug.Log("Growth Stage 3");
    //        BoundsInt bounds = growingCrops[0].cellBounds;

    //        foreach (var position in bounds.allPositionsWithin)
    //        {
    //            if (growingCrops[0].HasTile(position))
    //            {
    //                growingCrops[0].SetTile(position, cropTiles.growthStageThree[0]);
    //            }
    //        }
    //    }
    //    else if (cropGrowTimer >= 15)
    //    {
    //        Debug.Log("crops are harvestable and fully grown");

    //        BoundsInt bounds = growingCrops[0].cellBounds;

    //        foreach (var position in bounds.allPositionsWithin)
    //        {
    //            if (growingCrops[0].HasTile(position))
    //            {
    //                growingCrops[0].SetTile(position, cropTiles.harvestable[0]);
    //            }
    //        }
    //        cropsPlanted = false;
    //        cropsHarvestable = true;
    //        cropGrowTimer = 0f;
    //    }
    //}




}
