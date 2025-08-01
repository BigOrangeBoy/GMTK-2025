using UnityEngine;

public class OutlineMarker : MonoBehaviour
{
    internal void ShowOutline(bool state)
    {
        gameObject.layer = state ? 6 : 0;
    }
}