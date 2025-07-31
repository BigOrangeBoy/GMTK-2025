using UnityEngine;

public class FPPLookBehaviour : MonoBehaviour
{
    [Header("Essential Variables")]
    [SerializeField] float baseSensitivity = 100f;
    [SerializeField] Transform plrMesh;

    private float xRotation = 0f;
    public bool lookAllowed = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!lookAllowed)
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * baseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * baseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -75f, 70f); //-65, 50

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        plrMesh.Rotate(Vector3.up * mouseX);
    }

    public void SetCursorState(bool state)
    {
        if (state)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}