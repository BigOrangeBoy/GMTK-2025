using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractUIManager : MonoBehaviour
{
    public static InteractUIManager instance;

    [SerializeField] private CanvasGroup crosshairGroup;
    [SerializeField] private Animator messageAnimator;
    [SerializeField] private Text messageTextBox;

    private Coroutine messageCoroutine = null;


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

    internal void ToggleCrosshair(bool state)
    {
        state = !state;
        crosshairGroup.alpha = state ? 1 : 0;
    }

    internal void DisplayInteractionMessage(string message)
    {
        messageTextBox.text = message;

        if (messageCoroutine == null)
        {
            messageCoroutine = StartCoroutine(DisplayMessage());
        }
    }

    IEnumerator DisplayMessage()
    {
        messageAnimator.SetBool("isActive", true);
        yield return new WaitForSeconds(6f);
        messageAnimator.SetBool("isActive", false);
        messageCoroutine = null;
    }
}