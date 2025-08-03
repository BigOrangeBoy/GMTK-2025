using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [Header("Input Keys")]
    [SerializeField] KeyCode escapeKey = KeyCode.Escape;

    private PlayerMovement plrMovement;
    private FPPLookBehaviour mouseBehaviour;

    internal bool haveCursor = false;
    internal bool isPaused = false;
    internal bool isInteracting = false;
    internal bool isInEvent = true;

    private void Awake()
    {
        plrMovement = GetComponent<PlayerMovement>();
        mouseBehaviour = GetComponentInChildren<FPPLookBehaviour>();
    }

    private void Update()
    {
        HandleCursorAndPause();
    }

    private void HandleCursorAndPause()
    {
        if (Input.GetKeyUp(escapeKey) && !isInteracting && !isInEvent)
        {
            isPaused = !isPaused;
            if (!haveCursor)
            {
                FreezePlayer();
                GamePlayUI.instance.TogglePause();
            }
            else
            {
                FreezePlayer();
                GamePlayUI.instance.TogglePause();
            }
        }
    }

    private void FreezePlayer()
    {
        haveCursor = !haveCursor;
        Cursor.visible = haveCursor;

        mouseBehaviour.SetCursorState(!haveCursor);
        plrMovement.moveAllowed = !haveCursor;
        mouseBehaviour.lookAllowed = !haveCursor;
    }
}