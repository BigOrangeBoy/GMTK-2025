using System.Collections;
using UnityEngine;

public class ObjectInteractor : MonoBehaviour
{
    [Header("Interactor Settings")]
    [SerializeField] private float interactDistance = 12f;
    private Camera mainCamera;

    private PlayerInputManager plrInput = null;
    private InteractObject currentInteractableObject = null;
    private bool isHighlightVisible = false;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        plrInput = InteractDisableManager.instance.player.GetComponent<PlayerInputManager>();
    }

    private void Update()
    {
        RaycastHit rayHit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out rayHit, interactDistance))
        {
            ClearInteractables();
            return;
        }

        InteractObject interactableObject = GetInteractableObject(rayHit.collider);

        if (interactableObject != null)
        {
            currentInteractableObject = interactableObject;
            HighlightInteractUI(true, currentInteractableObject.itemName);
        }
        else
        {
            ClearInteractables();
        }
        if (Input.GetKeyDown(KeyCode.E) && !plrInput.isPaused)
        {
            if (currentInteractableObject != null)
            {
                TryInteract();
            }
            else
            {
                Debug.Log("[Interactor]: No Interactable Object Found!");
            }
        }
    }

    private void ClearInteractables()
    {
        if (currentInteractableObject != null)
        {
            currentInteractableObject = null;
            HighlightInteractUI(false, null);
        }
    }

    private void HighlightInteractUI(bool state, string itemName = null)
    {
        if (isHighlightVisible == state)
        {
            return;
        }
        isHighlightVisible = state;
        //InteractUIManager.instance.HighlightShowUI(isHighlightVisible, itemName);
    }

    private void TryInteract()
    {
        if (currentInteractableObject == null)
        {
            return;
        }
        else
        {
            StartCoroutine(HandleQuickItemInteraction(currentInteractableObject));
        }

        HighlightInteractUI(false, null);
    }

    private IEnumerator HandleQuickItemInteraction(InteractObject eventItem)
    {
        eventItem.isInteracting = true;
        eventItem.InteractWithObject();

        yield return new WaitForSeconds(1f);

        eventItem.isInteracting = false;
        eventItem.EndInteraction();
    }

    private InteractObject GetInteractableObject(Collider collider)
    {
        return collider.CompareTag("InteractableObject") ? collider.GetComponent<InteractObject>() : null;
    }
}
