using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject objectsToHide;
    [SerializeField] private string collectableName;

    internal void InitilizeSystem()
    {
        Debug.Log("Item Collected");
        InteractObject interaction = GetComponent<InteractObject>();
        interaction.enabled = false;
        gameObject.tag = "Untagged";
        gameObject.layer = 0;

        StartEvent();
    }

    private void StartEvent()
    {
        if (collectableName == "Canned_food")
        {
            PlayerItems.instance.hasCannedFood = true;
        }
        else if (collectableName == "Vegetables")
        {
            PlayerItems.instance.hasVegetables = true;
        }
        else if (collectableName == "Apples")
        {
            PlayerItems.instance.hasApples = true;
        }
        else if (collectableName == "Gas_Hose")
        {
            PlayerItems.instance.hasGasHose = true;
        }
        else if (collectableName == "ToolBox")
        {
            PlayerItems.instance.hasToolBox = true;
        }

        Destroy(objectsToHide);
    }
}