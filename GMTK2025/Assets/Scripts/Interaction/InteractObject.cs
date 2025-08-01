using UnityEngine;

public enum EventItem : byte
{
    Knot, Telephone
}

public class InteractObject : MonoBehaviour
{
    [Header("Interact Object Settings:")]
    [SerializeField] internal EventItem eventItem;
    [SerializeField] internal string itemName;

    internal bool isInteracting = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isInteracting)
        {
            isInteracting = false;
            EndInteraction();
        }
    }

    internal void InteractWithObject()
    {
        if (eventItem == EventItem.Knot)
        {
            //BehaviourScript script = gameObject.GetComponent<BehaviourScript>();
            //script.InitilizeSystem();
        }
        else if (eventItem == EventItem.Telephone)
        {
            TelephoneBehaviour telephoneScript = gameObject.GetComponent<TelephoneBehaviour>();
            telephoneScript.InitilizeSystem();
        }
    }

    internal void EndInteraction()
    {
        InteractDisableManager.instance.ToggleInteractingPlayer(false);
        Debug.Log($"Interaction ended with: {itemName}");
    }

    internal void HandleInvalidInteraction()
    {
        Debug.Log("Invalid Interaction");
    }
}