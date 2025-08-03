using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public static PlayerItems instance;

    public bool hasCannedFood = false;
    public bool hasVegetables = false;
    public bool hasApples = false;
    public bool hasGasHose = false;
    public bool hasToolBox = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public bool hasBoughtGroceries()
    {
        return hasCannedFood && hasVegetables && hasApples;
    }
}