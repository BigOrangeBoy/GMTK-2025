using System.Collections;
using UnityEngine;

public class TelephoneBehaviour : MonoBehaviour
{
    [TextArea(2, 4)]
    [SerializeField] private string message;
    [SerializeField] private AudioSource alarmSource;
    [SerializeField] private Animator vehicleAnimator;

    private Coroutine alarmCoroutine = null;

    internal void InitilizeSystem()
    {
        Debug.Log("Tchaikovsky!!!!");

        if (alarmCoroutine == null)
        {
            InteractObject interaction = GetComponent<InteractObject>();
            interaction.enabled = false;
            gameObject.tag = "Untagged";
            gameObject.layer = 0;
            alarmCoroutine = StartCoroutine(RaiseAlarms());
        }
    }

    IEnumerator RaiseAlarms()
    {
        InteractUIManager.instance.DisplayInteractionMessage(message);

        yield return new WaitForSeconds(2f);

        if (!alarmSource.isPlaying)
        {
            alarmSource.Play();
        }

        yield return new WaitForSeconds(1f);

        vehicleAnimator.SetBool("isRunning", true);
    }
}