using UnityEngine;

public enum EventItem : byte
{
    Knot, Telephone, Collectable, Checkout
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
            KnotBehaviour knotScript = gameObject.GetComponent<KnotBehaviour>();
            knotScript.InitilizeSystem();
        }
        else if (eventItem == EventItem.Telephone)
        {
            TelephoneBehaviour telephoneScript = gameObject.GetComponent<TelephoneBehaviour>();
            telephoneScript.InitilizeSystem();
        }
        else if (eventItem == EventItem.Collectable)
        {
            CollectableBehaviour collectableScript = gameObject.GetComponent<CollectableBehaviour>();
            collectableScript.InitilizeSystem();
        }
        else if (eventItem == EventItem.Checkout)
        {
            CheckoutBehaviour checkoutScript = gameObject.GetComponent<CheckoutBehaviour>();
            checkoutScript.InitilizeSystem();
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