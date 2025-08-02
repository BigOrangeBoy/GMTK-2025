using UnityEngine;

public class KnotBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToHide;
    [SerializeField] private Rigidbody boxRigidBody;

    internal void InitilizeSystem()
    {
        Debug.Log("J.S Bach!");
        InteractObject interaction = GetComponent<InteractObject>();
        interaction.enabled = false;
        gameObject.tag = "Untagged";
        gameObject.layer = 0;

        StartEvent();
    }

    private void StartEvent()
    {
        foreach (var objs in objectsToHide)
        {
            objs.SetActive(false);
        }

        boxRigidBody.isKinematic = false;
    }
}
