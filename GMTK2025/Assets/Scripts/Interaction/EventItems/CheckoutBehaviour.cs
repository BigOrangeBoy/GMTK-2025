using UnityEngine;

public class CheckoutBehaviour : MonoBehaviour
{
    internal void InitilizeSystem()
    {
        Debug.Log("Checkout Completed");
        InteractObject interaction = GetComponent<InteractObject>();
        interaction.enabled = false;
        gameObject.tag = "Untagged";
        gameObject.layer = 0;

        StartEvent();
    }

    private void StartEvent()
    {
        if (PlayerItems.instance.hasBoughtGroceries())
        {
            EventBehaviour.instance.hasBoughtGroceries = true;
            //Unlock SuperMarket Door
            QuestBehaviour.instance.ProcessFirstQuest();
        }
        else
        {
            Debug.Log("Player must buy all items!");
            return;
        }
    }
}