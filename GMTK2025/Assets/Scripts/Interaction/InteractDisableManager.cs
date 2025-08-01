using UnityEngine;

public class InteractDisableManager : MonoBehaviour
{
    public static InteractDisableManager instance;

    public GameObject player = null;
    [SerializeField] private ObjectInteractor interactor = null;

    private void Awake()
    {
        if (instance != this)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void ToggleInteractingPlayer(bool isDisabled)
    {
        if (isDisabled)
        {
            if (player != null)
            {
                player.GetComponent<PlayerMovement>().moveAllowed = false;
                player.GetComponentInChildren<FPPLookBehaviour>().lookAllowed = false;
                player.GetComponent<PlayerInputManager>().isInteracting = true;
            }
            else
            {
                Debug.Log("[Interact Disable Manager]: Player object is null!");
            }
            interactor.enabled = false;
            InteractUIManager.instance.ToggleCrosshair(false);
        }
        else
        {
            if (player != null)
            {
                player.GetComponent<PlayerMovement>().moveAllowed = true;
                player.GetComponentInChildren<FPPLookBehaviour>().lookAllowed = true;
                player.GetComponent<PlayerInputManager>().isInteracting = false;
            }
            else
            {
                Debug.Log("[Interact Disable Manager]: Player object is null!");
            }
            interactor.enabled = true;
            InteractUIManager.instance.ToggleCrosshair(true);
        }
    }
}