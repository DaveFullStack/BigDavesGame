using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInventory : MonoBehaviour
{

    

    public GameObject coffeePanel;

    public void OnCoffeeButtonClick()
    {
        if (!coffeePanel.activeInHierarchy)
        {
            coffeePanel.SetActive(true);
        }
    }


}
